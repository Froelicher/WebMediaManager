using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class Playlists
    {
        [DataMember]
        public string kind { get; set; }

        [DataMember]
        public string etag { get; set; }

        [DataMember]
        public string id { get; set; }

        [DataContract]
        public class Snippet
        {
            [DataMember]
            public DateTime publishedAt { get; set; }

            [DataMember]
            public string channelId { get; set; }

            [DataMember]
            public string title { get; set; }

            [DataMember]
            public string description { get; set; }

            [DataMember]
            public Thumbnails thumbnails { get; set; }

            [DataMember]
            public string channelTitle { get; set; }

            [DataMember]
            public string[] tags { get; set; }
        }

        public Snippet snippet { get; set; }

        [DataContract]
        public class Status
        {
            [DataMember]
            public string privacyStatus { get; set; }
        }

        [DataMember]
        public Status status { get; set; }

        [DataContract]
        public class ContentDetails
        {
            [DataMember]
            public int itemCount { get; set; }
        }

        [DataMember]
        public ContentDetails contentDetails { get; set; }

        [DataContract]
        public class Player
        {
            [DataMember]
            public string embedHtml { get; set; }
        }

        [DataMember]
        public Player player { get; set; }
    }
}
