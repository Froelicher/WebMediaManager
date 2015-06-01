/*
 * Author : JP. Froelicher
 * Description : Featureds
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

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
