using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class Thumbnails
    {
        [DataContract]
        public class Param
        {
            [DataMember]
            public string url { get; set; }

            [DataMember]
            public string width { get; set; }

            [DataMember]
            public string height { get; set; }
        }

        [DataMember]
        public Param Default { get; set; }

        [DataMember]
        public Param medium { get; set; }

        [DataMember]
        public Param high { get; set; }
    }
}
