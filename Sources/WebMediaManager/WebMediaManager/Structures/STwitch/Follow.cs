/*
 * Author : JP. Froelicher
 * Description : Follow
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
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
