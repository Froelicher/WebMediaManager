using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class ResourceId
    {
        [DataMember]
        public string kind { get; set; }

        [DataMember]
        public string videoId { get; set; }

        [DataMember]
        public string channelId { get; set; }

        [DataMember]
        public string playlistId { get; set; }
    }
}
