using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordpressDesktopClient
{
    public class DataManager
    {
        private List<YoutubeEntry> youtubeEntries;
        private List<BlogEntry> blogEntries;
        private List<int> tagIds;
        private List<Tag> tags;
        private static string connetionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public DataManager() {}

        private DateTime getUTCTime()
        {
            return DateTime.Now.AddHours(-2);
        }

        private string getFormattedTime(DateTime time)
        {
            return time.ToString("yyyy-MM-dd H:mm:ss");
        }

        public void publish(BlogEntry entry)
        {
            using (var connection = new MySqlConnection(connetionString))
            using (var command = connection.CreateCommand())
            {

                command.CommandText = "INSERT INTO " +
                "cb_posts(ID, post_author, post_date, post_date_gmt, post_content, post_title, post_excerpt, post_status, comment_status, ping_status, post_password, post_name, to_ping, pinged, post_modified, post_modified_gmt, post_content_filtered, post_parent, guid, menu_order, post_type, post_mime_type, comment_count) " +
                "VALUES (@ID, @post_author, @post_date, @post_date_gmt, @post_content, @post_title, @post_excerpt, @post_status, @comment_status, @ping_status, @post_password, @post_name, @to_ping, @pinged, @post_modified, @post_modified_gmt, @post_content_filtered, @post_parent, @guid, @menu_order, @post_type, @post_mime_type, @comment_count)";

                connection.Open();

                command.Parameters.AddWithValue("@ID", entry.Id);
                command.Parameters.AddWithValue("@post_author", 1);
                command.Parameters.AddWithValue("@post_date", getFormattedTime(getUTCTime()));
                command.Parameters.AddWithValue("@post_date_gmt", getFormattedTime(DateTime.Now));
                command.Parameters.AddWithValue("@post_content", entry.Content);
                command.Parameters.AddWithValue("@post_title", entry.Title);
                command.Parameters.AddWithValue("@post_excerpt", "");
                command.Parameters.AddWithValue("@post_status", "publish");
                command.Parameters.AddWithValue("@comment_status", "open");
                command.Parameters.AddWithValue("@ping_status", "open");
                command.Parameters.AddWithValue("@post_password", "");
                command.Parameters.AddWithValue("@post_name", entry.Name);
                command.Parameters.AddWithValue("@to_ping", "");
                command.Parameters.AddWithValue("@pinged", "");
                command.Parameters.AddWithValue("@post_modified", "");
                command.Parameters.AddWithValue("@post_modified_gmt", "");
                command.Parameters.AddWithValue("@post_content_filtered", "");
                command.Parameters.AddWithValue("@post_parent", 0);
                command.Parameters.AddWithValue("@guid", "http://telewizjatychy.pl/?p=" + entry.Id);
                command.Parameters.AddWithValue("@menu_order", 0);
                command.Parameters.AddWithValue("@post_type", "post");
                command.Parameters.AddWithValue("@post_mime_type", "");
                command.Parameters.AddWithValue("@comment_count", 0);
                command.ExecuteNonQuery();
            }
            setTags(entry);
            entry.IsPosted = true;
        }

        private void setTags(BlogEntry entry)
        {
            using (var connection = new MySqlConnection(connetionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                foreach(int tag in entry.TagIds)
                {
                    command.CommandText = $"INSERT INTO cb_term_relationships (object_id, term_taxonomy_id, term_order) VALUES ({entry.Id}, {tag}, 0)";
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<int> populateTagList(int postID)
        {
            tagIds = new List<int>();
            using (var connection = new MySqlConnection(connetionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = $"SELECT term_taxonomy_id FROM `cb_term_relationships` WHERE object_id LIKE {postID};";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tagIds.Add(reader.GetInt32(0));
                    }
                    connection.CloseAsync();
                }
            }
            return tagIds;
        }

        public List<Tag> GetTags()
        {
            tags = new List<Tag>();
            using (var connection = new MySqlConnection(connetionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT cb_terms.name, cb_term_taxonomy.term_id, cb_term_taxonomy.parent FROM `cb_terms`, `cb_term_taxonomy` WHERE cb_terms.term_id = cb_term_taxonomy.term_id AND cb_term_taxonomy.taxonomy LIKE \u0022category\u0022;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        int id = reader.GetInt32(1);
                        int parent = reader.GetInt32(2);
                        Tag tag = new Tag(name, id, parent);
                        tags.Add(tag);
                    }
                    connection.CloseAsync();
                }
            }
            return tags;
        }

        private void loadBlogEntries(int count)
        {
            blogEntries = new List<BlogEntry>();
            using (var connection = new MySqlConnection(connetionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = $"SELECT * FROM cb_posts WHERE post_status LIKE 'publish' ORDER BY id DESC LIMIT 0, {count};";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BlogEntry blogEntry = new BlogEntry(reader.GetString(4), reader.GetInt32(0))
                        {
                            Date = reader.GetDateTime(2),
                            DateGMT = reader.GetDateTime(3),
                            Title = reader.GetString(5),
                            Name = reader.GetString(10),
                            GUID = reader.GetString(19)
                        };
                        blogEntry.generateName();
                        blogEntries.Add(blogEntry);
                    }
                    connection.CloseAsync();
                }
                foreach (var blogEntry in blogEntries)
                    blogEntry.TagIds = populateTagList(blogEntry.Id);
            }
        }

        private void loadYoutubeEntries(int count)
        {
            youtubeEntries = new List<YoutubeEntry>();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = ConfigurationManager.AppSettings["ApiKey"],
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.ChannelId = ConfigurationManager.AppSettings["ChannelId"];
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
            searchListRequest.MaxResults = count;

            var searchListResponse = searchListRequest.Execute();

            var videosListRequest = youtubeService.Videos.List("snippet");
            List<string> videos = new List<string>();
            foreach (var searchResult in searchListResponse.Items)
            {
                videosListRequest.Id = videosListRequest.Id + searchResult.Id.VideoId + ",";
                videos.Add(searchResult.Id.VideoId);
            }
            
            var videosListResponse = videosListRequest.Execute();

            for (int i = 0; i < videosListResponse.Items.Count; i++)
            {
                youtubeEntries.Add(new YoutubeEntry() {
                    Title = videosListResponse.Items[i].Snippet.Title.ToString(),
                    Description = videosListResponse.Items[i].Snippet.Description.ToString(),
                    VideoID = videos[i],
                    Number = i,
                    PublicationDate =
                        ((DateTime)videosListResponse.Items[i].Snippet.PublishedAt)
                        .ToString(YoutubeEntry.DateFormat),
                    Timestamp = ((DateTime)videosListResponse.Items[i].Snippet.PublishedAt)
                });
            }
        }

        public List<BlogEntry> getComparedEntries(int count)
        {
            loadBlogEntries(count);
            loadYoutubeEntries(count);
            HashSet<BlogEntry> entrySet = new HashSet<BlogEntry>();
            foreach(var entry in blogEntries)
            {
                entrySet.Add(entry);
            }
            foreach(var entry in youtubeEntries)
            {
                entrySet.Add(new BlogEntry(entry));
            }
            var entryList = entrySet.OrderBy(e => e.Date).ToList();
            foreach(var e in entryList)
            {
                if (!e.IsPosted)
                {
                    e.incrementNumbers();
                    e.Content = generateContent(e);
                }
            }
            entryList.Sort();
            return entryList;
        }

        private string generateContent(YoutubeEntry entry)
        {
            string code = "<div style=\"left: 7pt; top: 15pt; position: absolute; font-family: Tahoma, Arial, Helvetica, Sans-Serif; font-weight: bold; font-size:24px; padding: 3px; letter-spacing: 1px;\">[" +
                entry.Number + "]</div>" + "<table>" + "<tr>" + "<td><center><font size=\"5\"> " +
                entry.PublicationDate + "</font></center><iframe width=\"450\" height=\"360\" src=\"https://www.youtube.com/embed/" +
                entry.VideoID + "\" frameborder=\"0\" gesture=\"media\" allowfullscreen></iframe></td><td>" +
                entry.Description + "<center><a href=\"https://www.youtube.com/watch?v=" +
                entry.VideoID + "\">Oglądaj cały film ...</a></center>" + "</td>\r\n</tr>\r\n</table>";
            return code;
        }

    }
}
