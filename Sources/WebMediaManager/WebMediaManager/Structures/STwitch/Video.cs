using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAlert.TwitchModels
{
    [DataContract]
    class Video
    {
        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public long broadcast_id { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string tag_list { get; set; }

        [DataMember]
        public string _id { get; set; }

        [DataMember]
        public string game { get; set; }

        [DataMember]
        public int length { get; set; }

        [DataMember]
        public string preview { get; set; }

        [DataMember]
        public string url { get; set; }

        [DataMember]
        public int view { get; set; }

        [DataMember]
        public string broadcast_type { get; set; }

        [DataContract]
        public class VideoLinks
        {
            [DataMember]
            public string self { get; set; }

            [DataMember]
            public string channel { get; set; }
        }

        [DataMember]
        public VideoLinks _links { get; set; }

        [DataMember]
        public Channel channel { get; set; }

    }
}
