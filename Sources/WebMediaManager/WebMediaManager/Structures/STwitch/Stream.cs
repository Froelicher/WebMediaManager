using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    public class Stream
    {
        [DataMember]
        public long _id { get; set; }

        [DataMember]
        public string game { get; set; }

        [DataMember]
        public int viewers { get; set; }

        [DataMember]
        public float average_fps { get; set; }

        [DataMember]
        public int video_height { get; set; }

        [DataMember]
        public DateTime created_at { get; set; }

        [DataMember]
        public StreamLinks _links { get; set; }

        [DataContract]
        public class StreamLinks
        {
            [DataMember]
            public string self { get; set; }
        }

        [DataMember]
        public Image preview { get; set; }

        [DataMember]
        public Channel channel { get; set; }

    }
}
