/*
 * Author : JP. Froelicher
 * Description : Team
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

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
