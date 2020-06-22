using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordpressDesktopClient
{
    public class YoutubeEntry 
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string VideoID { get; set; }
        public bool IsPosted { get; set; }
        public string Description { get; set; }
        public string PublicationDate { get; set; }
        public static string DateFormat = "MMMM yyyy";
        public DateTime Timestamp { get; set; }

        public YoutubeEntry()
        {
            IsPosted = false;
        }

        protected virtual bool Equals(YoutubeEntry that)
        {
            if (ReferenceEquals(that, null))
                return false;
            else if (ReferenceEquals(that, this))
                return true;
            else
                return VideoID.Equals(that.VideoID);
        }
    }
}
