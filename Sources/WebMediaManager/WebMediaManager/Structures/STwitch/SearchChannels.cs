using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TwitchAlert.TwitchModels;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class SearchChannels
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
        public Channel[] channels { get; set; }

        [DataMember]
        public int _total { get; set; }
    }
}
