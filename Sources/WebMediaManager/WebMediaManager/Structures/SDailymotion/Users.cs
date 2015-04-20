using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SDailymotion
{
    [DataContract]
    class Users
    {
        [DataMember]
        public int page { get; set; }

        [DataMember]
        public int limit { get; set; }

        [DataMember]
        public bool Explicit { get; set; }

        [DataMember]
        public int total { get; set; }

        [DataMember]
        public bool has_more { get; set; }

        [DataMember]
        public User[] list { get; set; }
    }
}
