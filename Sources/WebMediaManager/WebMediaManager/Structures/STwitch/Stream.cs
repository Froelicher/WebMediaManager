/*
 * Author : JP. Froelicher
 * Description : Stream
 * Date : 16/04/2015
 */
using System;
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    public class Stream
    {
        [DataMember]
        public long _id { get; set; }

        [DataMember]
        public string game { get; set; }

        [DataMember]
        public int viewers { get; set; }

        [DataMember]
        public float average_fps { get; set; }

        [DataMember]
        public int video_height { get; set; }

        [DataMember]
        public DateTime created_at { get; set; }

        [DataMember]
        public StreamLinks _links { get; set; }

        [DataContract]
        public class StreamLinks
        {
            [DataMember]
            public string self { get; set; }
        }

        [DataMember]
        public Image preview { get; set; }

        [DataMember]
        public Channel channel { get; set; }

    }
}
