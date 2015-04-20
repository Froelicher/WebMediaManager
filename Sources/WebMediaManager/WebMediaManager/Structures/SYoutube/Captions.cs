using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class Captions
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
            public string videoId { get; set; }

            [DataMember]
            public DateTime lastUpdated { get; set; }

            [DataMember]
            public string trackKind { get; set; }

            [DataMember]
            public string language { get; set; }

            [DataMember]
            public string name { get; set; }

            [DataMember]
            public string audioTrackType { get; set; }

            [DataMember]
            public bool isCC { get; set; }

            [DataMember]
            public bool isLarge { get; set; }

            [DataMember]
            public bool isEasyReader { get; set; }

            [DataMember]
            public bool isDraft { get; set; }

            [DataMember]
            public bool isAutoSynced { get; set; }

            [DataMember]
            public string status { get; set; }

            [DataMember]
            public string failureReason { get; set; }
        }

        [DataMember]
        public Snippet snippet { get; set; }
    }
}
