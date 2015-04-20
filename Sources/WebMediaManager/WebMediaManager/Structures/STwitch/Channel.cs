using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TwitchAlert.TwitchModels
{
    [DataContract]
    class Channel
    {
        [DataMember]
        public string mature { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string broadcaster_language { get; set; }

        [DataMember]
        public string display_name { get; set; }
        
        [DataMember]
        public string game { get; set; }
        
        [DataMember]
        public int delay { get; set; }

        [DataMember]
        public string language { get; set; }

        [DataMember]
        public int _id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string created_at { get; set; }

        [DataMember]
        public string updated_at { get; set; }

        [DataMember]
        public string logo { get; set; }

        [DataMember]
        public string banner { get; set; }

        [DataMember]
        public string video_banner { get; set; }

        [DataMember]
        public string background { get; set; }

        [DataMember]
        public string profile_banner { get; set; }

        [DataMember]
        public string profile_banner_background_color { get; set; }

        [DataMember]
        public string partner { get; set; }

        [DataMember]
        public string url { get; set; }

        [DataMember]
        public int views { get; set; }

        [DataMember]
        public int followers { get; set; }

        [DataMember]
        public ChannelLinks _links { get; set; }

        [DataContract]
        public class ChannelLinks
        {
            [DataMember]
            public string follows { get; set; }

            [DataMember]
            public string commercial { get; set; }

            [DataMember]
            public string stream_key { get; set; }

            [DataMember]
            public string chat { get; set; }

            [DataMember]
            public string features { get; set; }

            [DataMember]
            public string subscriptions { get; set; }

            [DataMember]
            public string editors { get; set; }

            [DataMember]
            public string teams { get; set; }

            [DataMember]
            public string videos { get; set; }
        }  
    }
}
