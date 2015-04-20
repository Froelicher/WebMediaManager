using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAlert.TwitchModels
{
    [DataContract]
    class Games
    {
        [DataMember]
        public int _total { get; set; }

        [DataMember]
        public GamesLinks _links { get; set; }

        [DataContract]
        public class GamesLinks
        {
            [DataMember]
            public string self { get; set; }

            [DataMember]
            public string next { get; set; }
        }

        [DataMember]
        public Top[] top { get; set; }

        [DataContract]
        public class Top
        {
            [DataMember]
            public int viewers { get; set; }

            [DataMember]
            public int channels { get; set; }

            [DataMember]
            public Game game { get; set; }
        }

    }
}
