using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class CommentThreads
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
            public string channelId { get; set; }

            [DataMember]
            public string videoId { get; set; }

            [DataMember]
            public Comments topLevelComment { get; set; }

            [DataMember]
            public bool canReply { get; set; }

            [DataMember]
            public int totalReplyCount { get; set; }

            [DataMember]
            public bool isPublic { get; set; }
        }

        [DataMember]
        public Snippet snippet { get; set; }

        [DataContract]
        public class Replies
        {
            [DataMember]
            public Comments[] comments { get; set; }
        }

        [DataMember]
        public Replies replies { get; set; }
    }
}
