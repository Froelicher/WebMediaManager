/*
 * Author : JP. Froelicher
 * Description : Search streams
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class SearchStreams
    {
        [DataContract]
        public class SearchLinks
        {
            [DataMember]
            public string self { get; set; }

            [DataMember]
            public string next { get; set; }
        }

        [DataMember]
        public SearchLinks _links { get; set; }

        [DataMember]
        public Stream[] streams { get; set; }

    }
}
