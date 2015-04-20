using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class Activities
    {
        [DataMember]
        public string king { get; set; }

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
            public string channelTitle { get; set; }

            [DataMember]
            public string type { get; set; }

            [DataMember]
            public string groupId { get; set; }
        }

        [DataMember]
        public Snippet snippet { get; set; }


        [DataContract]
        public class ContentDetails
        {
            //UPLOAD
            [DataContract]
            public class Upload
            {
                [DataMember]
                public string videoId { get; set; }
            }

            [DataMember]
            public Upload upload { get; set; }

            //LIKE
            [DataContract]
            public class Like
            {
                [DataMember]
                public ResourceId resourceId { get; set; }
            }

            [DataMember]
            public Like like { get; set; }

            //FAVORITE
            [DataContract]
            public class Favorite
            {
                [DataMember]
                public ResourceId resourceId { get; set; }
            }

            [DataMember]
            public Favorite favorite { get; set; }

            //COMMENT
            [DataContract]
            public class Comment
            {
                [DataMember]
                public ResourceId resourceId { get; set; }
            }

            [DataMember]
            public Comment comment { get; set; }

            //SUBSCRIPTION
            [DataContract]
            public class Subscription
            {
                [DataMember]
                public ResourceId resourceId { get; set; }
            }

            [DataMember]
            public Subscription subscription { get; set; }

            //PLAYLISTITEM
            [DataContract]
            public class PlaylistItem
            {
                [DataMember]
                public ResourceId resourceId { get; set; }

                [DataMember]
                public string playlistId { get; set; }

                [DataMember]
                public string playlistItemId { get; set; }
            }

            [DataMember]
            public PlaylistItem playlistItem { get; set; }

            //RECOMMENDATION
            [DataContract]
            public class Recommendation
            {
                [DataMember]
                public ResourceId resourceId { get; set; }

                [DataMember]
                public string reason { get; set; }

                [DataContract]
                public class SeedResourceId
                {
                    [DataMember]
                    public string king { get; set; }

                    [DataMember]
                    public string videoId { get; set; }

                    [DataMember]
                    public string channelId { get; set; }

                    [DataMember]
                    public string playlistId { get; set; }
                }

                [DataMember]
                public SeedResourceId seedresourceId { get; set; }
            }

            [DataMember]
            public Recommendation recommendation { get; set; }

            //BULLETIN
            [DataContract]
            public class Bulletin
            {
                [DataMember]
                public ResourceId resourceId { get; set; }
            }

            [DataMember]
            public Bulletin bulletin { get; set; }

            //SOCIAL
            [DataContract]
            public class Social
            {
                [DataMember]
                public string type { get; set; }

                [DataMember]
                public ResourceId resourceId { get; set; }

                [DataMember]
                public string author { get; set; }

                [DataMember]
                public string referenceUrl { get; set; }

                [DataMember]
                public string imageUrl { get; set; }
            }

            [DataMember]
            public Social social { get; set; }

            //CHANNELITEM
            [DataContract]
            public class ChannelItem
            {
                [DataMember]
                public ResourceId resourceId { get; set; }
            }

            [DataMember]
            public ChannelItem channelItem { get; set; }
        }






    }
}
