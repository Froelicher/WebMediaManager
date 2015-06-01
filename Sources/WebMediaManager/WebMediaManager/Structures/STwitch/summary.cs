/*
 * Author : JP. Froelicher
 * Description : Summary
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

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
