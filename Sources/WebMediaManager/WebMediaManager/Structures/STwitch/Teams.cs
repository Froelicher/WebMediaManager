/*
 * Author : JP. Froelicher
 * Description : Teams
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

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
