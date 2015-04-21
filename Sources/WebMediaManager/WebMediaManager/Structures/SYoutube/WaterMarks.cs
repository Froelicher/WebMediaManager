using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class WaterMarks
    {
        [DataContract]
        public class Timing
        {
            [DataMember]
            public string type { get; set; }

            [DataMember]
            public long offsetMs { get; set; }

            [DataMember]
            public long durationMs { get; set; }
        }

        [DataMember]
        public Timing timing { get; set; }

        [DataContract]
        public class Position
        {
            [DataMember]
            public string type { get; set; }

            [DataMember]
            public string cornerPosition { get; set; }
        }

        [DataMember]
        public Position position { get; set; }

        [DataMember]
        public string imageUrl { get; set; }

        [DataMember]
        public Byte imageBytes { get; set; }

        [DataMember]
        public string targetChannelId { get; set; }

    }
}
