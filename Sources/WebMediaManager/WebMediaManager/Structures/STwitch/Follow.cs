using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAlert.TwitchModels
{
    [DataContract]
    class Follow
    {
        [DataMember]
        public string created_at { get; set; }

        [DataContract]
        public class FollowsLinks
        {
            [DataMember]
            public string self { get; set; }
        }

        [DataMember]
        public FollowsLinks _links { get; set; }

        [DataMember]
        public string notifications { get; set; }

        [DataMember]
        public Channel channel { get; set; }

    }
}
