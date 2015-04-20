using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Summary
    {
        [DataMember]
        public int viewers { get; set; }

        [DataContract]
        public class SummaryLinks
        {
            [DataMember]
            public string self { get; set; }
        }

        [DataMember]
        public SummaryLinks _links { get; set; }

        [DataMember]
        public int channels { get; set; }
    }
}
