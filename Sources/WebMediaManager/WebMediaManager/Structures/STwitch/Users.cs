/*
 * Author : JP. Froelicher
 * Description : Users
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Users
    {
        [DataMember]
        public string display_name { get; set; }

        [DataMember]
        public string _id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string type { get; set; }

        [DataMember]
        public string bio { get; set; }

        [DataMember]
        public string created_at { get; set; }

        [DataMember]
        public string updated_at { get; set; }

        [DataMember]
        public string logo { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public bool partnered { get; set; }

        [DataMember]
        public UsersLinks _links { get; set; }

        [DataContract]
        public class UsersLinks
        {
            [DataMember]
            public string self { get; set; }
        }
    }
}
