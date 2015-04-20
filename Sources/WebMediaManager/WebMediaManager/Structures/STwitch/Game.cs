using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAlert.TwitchModels
{
    [DataContract]
    class Game
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int _id { get; set; }

        [DataMember]
        public int giantbomb_id { get; set; }

        [DataMember]
        public Image box { get; set; }

        [DataMember]
        public Image logo { get; set; }

        [DataContract]
        public class SearchImages
        {
            [DataMember]
            public string thumb { get; set; }

            [DataMember]
            public string tiny { get; set; }

            [DataMember]
            public string small { get; set; }

            [DataMember]
            public string super { get; set; }

            [DataMember]
            public string medium { get; set; }

            [DataMember]
            public string icon { get; set; }

            [DataMember]
            public string screen { get; set; }
        }

        [DataMember]
        public SearchImages images { get; set; }

        [DataMember]
        public int popularity { get; set; }
    }
}
