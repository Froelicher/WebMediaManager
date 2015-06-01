/*
 * Author : JP. Froelicher
 * Description : Featured
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Featured
    {
        [DataMember]
        public string image { get; set; }

        [DataMember]
        public string text { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public bool sponsored { get; set; }

        [DataMember]
        public bool scheduled { get; set; }

        [DataMember]
        public Stream stream { get; set; }
    }
}
