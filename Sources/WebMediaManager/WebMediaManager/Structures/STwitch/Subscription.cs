/*
 * Author : JP. Froelicher
 * Description : Subscription
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

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
