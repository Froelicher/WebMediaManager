﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class GuideCategories
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
            public string title { get; set; }
        }

        [DataMember]
        public Snippet snippet { get; set; }
    }
}
