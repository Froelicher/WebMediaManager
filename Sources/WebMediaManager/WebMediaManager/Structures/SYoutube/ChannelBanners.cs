using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class ChannelBanners
    {
        [DataMember]
        public string kind { get; set; }

        [DataMember]
        public string etag { get; set; }

        [DataMember]
        public string url { get; set; }
    }
}
