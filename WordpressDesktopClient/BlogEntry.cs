using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordpressDesktopClient
{
    public class BlogEntry : YoutubeEntry, IComparable<BlogEntry>
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateGMT { get; set; }
        public string Content { get; set; }
        public List<int> TagIds { get; set; }
        public string Name { get; set; }
        public string GUID { get; set; }

        public static int LastId { get; private set; } = 0;
        public static int LastNumber { get; private set; } = 0;

        private const int author = 1;
        

        public BlogEntry(string content, int id)
        {
            IsPosted = true;
            Content = content;
            Id = id;
            setVideoID();
            setNumber();
            setDescription();
            TagIds = new List<int>();
            generateGUID();
            generateNewEntryData();
        }
        
        public BlogEntry(YoutubeEntry entry)
        {
            foreach (PropertyInfo prop in entry.GetType().GetProperties())
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(entry, null), null);

            Description = ("<BR>&nbsp;&nbsp;&nbsp;&nbsp;" + Description)
                .Replace("https://patronite.pl/TelewizjaTychy", "<a href=\"https://patronite.pl/TelewizjaTychy\">patronite.pl/TelewizjaTychy</a>")
                .Replace("\n", "<BR>");
            generateGUID();
            generateName();
            Date = Timestamp;
            TagIds = new List<int>();
        }

        public void incrementNumbers()
        {
            Id = ++LastId;
            Number = ++LastNumber;
        }

        private void generateNewEntryData()
        {
            LastId = Id > LastId ? Id : LastId;
            LastNumber = Number > LastNumber ? Number : LastNumber;
        }

        private void setVideoID()
        {
            int index = Content.IndexOf("embed",225)+6;
            VideoID = Content.Substring(index, 11); 
        }

        private void setNumber()
        {
            int start = Content.IndexOf("[");
            int end = Content.IndexOf("]", start);
            Number = Convert.ToInt32(Content.Substring(start + 1, end - start - 1));
        }

        private void setDescription()
        {
            int start = Content.IndexOf("&nbsp");
            int end = Content.IndexOf("<center>", start);
            Description = "<BR>" + Content.Substring(start, end - start);
        }

        public void generateName()
        {
            string decomposed = Title.Normalize(NormalizationForm.FormD);
            char[] filtered = decomposed
                .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();
            string input = new string(filtered);
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            Name = rgx.Replace(input, "").Replace(' ', '-').ToLower();
        }

        public void generateGUID()
        {
            GUID = $"http://telewizjatychy.pl/?p={Id}";
        }

        public bool Equals(BlogEntry that)
        {
            if (ReferenceEquals(that, null))
                return false;
            else if (ReferenceEquals(that, this))
                return true;
            else
                return VideoID == that.VideoID;
        }

        public override bool Equals(object obj)
        {
            var other = obj as BlogEntry;
            if (other == null) return false;
            return VideoID.Equals(other.VideoID);
        }

        public override int GetHashCode()
        {
            return VideoID.GetHashCode();
        }

        public int CompareTo(BlogEntry other)
        {
            if (Number > other.Number) return -1;
            if (Number < other.Number) return 1;
            return 0;
        }
    }
}
