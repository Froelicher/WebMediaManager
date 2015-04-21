using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class Comments
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
            public string channelId { get; set; }

            [DataMember]
            public string videoId { get; set; }

            [DataMember]
            public string textDisplay { get; set; }

            [DataMember]
            public string textOriginal { get; set; }

            [DataMember]
            public string parentId { get; set; }

            [DataMember]
            public string authorDisplayName { get; set; }

            [DataMember]
            public string authorProfileImageUrl { get; set; }

            [DataMember]
            public string authorChannelUrl { get; set; }

            [DataContract]
            public class AuthorChannelId
            {
                [DataMember]
                public string value { get; set; }
            }

            [DataMember]
            public AuthorChannelId authorChannelId { get; set; }

            [DataMember]
            public string authorGoogleplusProfileUrl { get; set; }

            [DataMember]
            public bool canRate { get; set; }

            [DataMember]
            public string viewerRating { get; set; }

            [DataMember]
            public int likeCount { get; set; }

            [DataMember]
            public string moderationStatus { get; set; }

            [DataMember]
            public DateTime publishedAt { get; set; }

            [DataMember]
            public DateTime updatedAt { get; set; }
        }

        [DataMember]
        public Snippet snippet { get; set; }
    }
}
