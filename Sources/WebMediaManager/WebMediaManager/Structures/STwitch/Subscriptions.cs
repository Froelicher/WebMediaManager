using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Subscriptions
    {
        [DataMember]
        public int _total { get; set; }

        [DataMember]
        public Subscription[] subscriptions { get; set; }

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
