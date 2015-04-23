using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Featured
    {
        [DataMember]
        public string image { get; set; }

        [DataMember]
        public string text { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public bool sponsored { get; set; }

        [DataMember]
        public bool scheduled { get; set; }

        [DataMember]
        public Stream stream { get; set; }
    }
}
