/*
 * Author : JP. Froelicher
 * Description : Videos
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Videos
    {
        [DataMember]
        public int _total { get; set; }

        [DataContract]
        public class VideosLinks
        {
            [DataMember]
            public string self { get; set; }

            [DataMember]
            public string next { get; set; }
        }

        [DataMember]
        public VideosLinks _links { get; set; }

        [DataMember]
        public Video[] videos { get; set; }
    }
}
