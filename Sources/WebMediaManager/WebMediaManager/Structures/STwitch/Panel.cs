/*
 * Author : JP. Froelicher
 * Description : Panel
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Panel
    {
        [DataMember]
        public long _id { get; set; }

        [DataMember]
        public int display_order { get; set; }

        [DataContract]
        public class Data
        {
            [DataMember]
            public string link { get; set; }

            [DataMember]
            public string image { get; set; }

            [DataMember]
            public string title { get; set; }

            [DataMember]
            public string description { get; set; }
        }

        [DataMember]
        public Data data { get; set; }

        [DataMember]
        public string kind { get; set; }

        [DataMember]
        public string html_description { get; set; }

        [DataMember]
        public long user_id { get; set; }

        [DataMember]
        public string channel { get; set; }
    }
}
