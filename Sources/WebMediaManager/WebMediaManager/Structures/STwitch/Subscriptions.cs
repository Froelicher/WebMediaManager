/*
 * Author : JP. Froelicher
 * Description : Subscriptions
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

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
