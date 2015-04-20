using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SDailymotion
{
    [DataContract]
    class Comment
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public string owner { get; set; }
    }
}
