using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class Search
    {
        [DataMember]
        public string kind { get; set; }

        [DataMember]
        public string etag { get; set; }

        [DataContract]
        public class Id
        {
            [DataMember]
            public string kind { get; set; }

            [DataMember]
            public string videoId { get; set; }

            [DataMember]
            public string channelId { get; set; }

            [DataMember]
            public string playlistId { get; set; }
        }

        [DataMember]
        public Id id { get; set; }

        [DataContract]
        public class Snippet
        {
            [DataMember]
            public string publishedAt { get; set; }

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
            public string liveBroadcastContent { get; set; }
        }

        [DataMember]
        public Snippet snippet { get; set; }

    }
}
