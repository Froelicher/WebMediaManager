using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAlert.TwitchModels
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
