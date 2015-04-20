using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAlert.TwitchModels
{
    [DataContract]
    class Videos
    {
        [DataMember]
        public int _total { get; set; }

        [DataContract]
        public class VideosLinks
        {
            [DataMember]
            public string self { get; set; }

            [DataMember]
            public string next { get; set; }
        }

        [DataMember]
        public VideosLinks _links { get; set; }

        [DataMember]
        public Video[] videos { get; set; }
    }
}
