using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SDailymotion
{
    [DataContract]
    class Video
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string channel { get; set; }

        [DataMember]
        public string owner { get; set; }
    }
}
