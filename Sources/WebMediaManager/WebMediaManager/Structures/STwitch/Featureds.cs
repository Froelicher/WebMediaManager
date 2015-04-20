using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Featureds
    {
        [DataContract]
        public class FeaturedLinks
        {
            [DataMember]
            public string self { get; set; }

            [DataMember]
            public string next { get; set; }
        }

        public FeaturedLinks _links { get; set; }

        [DataMember]
        public Featured[] featureds { get; set; }

    }
}
