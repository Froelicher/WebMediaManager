/*
 * Author : JP. Froelicher
 * Description : Streams
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Streams
    {
        [DataMember]
        public StreamsLinks _links { get; set; }

        [DataContract]
        public class StreamsLinks
        {
            [DataMember]
            public string self { get; set; }

            [DataMember]
            public string channel { get; set; }
        }

        [DataMember]
        public Stream stream { get; set; }
        
        [DataMember]
        public Stream[] streams { get; set; }
    }
}
