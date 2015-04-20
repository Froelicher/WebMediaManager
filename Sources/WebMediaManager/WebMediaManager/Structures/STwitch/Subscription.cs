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
    class Subscription
    {
        [DataMember]
        public string _id { get; set; }

        [DataMember]
        public Users user { get; set; }

        [DataMember]
        public string created_at { get; set; }

        [DataContract]
        public class SubscriptionLinks
        {
            [DataMember]
            public string self { get; set; }
        }

        [DataMember]
        public SubscriptionLinks _links { get; set; }
    }
}
