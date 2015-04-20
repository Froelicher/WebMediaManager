using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SDailymotion
{
    [DataContract]
    class Activity
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string type { get; set; }

        [DataMember]
        public string from_title { get; set; }

        [DataMember]
        public string object_title { get; set; }
    }
}
