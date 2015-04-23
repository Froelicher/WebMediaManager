using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Teams
    {
        [DataContract]
        public class TeamLinks
        {
            [DataMember]
            public string next { get; set; }

            [DataMember]
            public string self { get; set; }
        }

        [DataMember]
        public TeamLinks _links { get; set; }

        [DataMember]
        public Team[] teams { get; set; }

    }
}
