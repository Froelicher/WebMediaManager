/*
 * Author : JP. Froelicher
 * Description : SearchChannels
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

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
