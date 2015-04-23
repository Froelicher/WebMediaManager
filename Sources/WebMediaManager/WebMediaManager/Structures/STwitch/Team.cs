using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Team
    {
        [DataMember]
        public int _id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string info { get; set; }

        [DataMember]
        public string display_name { get; set; }

        [DataMember]
        public string created_at { get; set; }

        [DataMember]
        public string updated_at { get; set; }

        [DataMember]
        public string logo { get; set; }

        [DataMember]
        public string banner { get; set; }

        [DataMember]
        public string background { get; set; }

        [DataContract]
        public class TeamsLinks
        {
            [DataMember]
            public string self { get; set; }
        }

        [DataMember]
        public TeamsLinks _links { get; set; }
    }
}
