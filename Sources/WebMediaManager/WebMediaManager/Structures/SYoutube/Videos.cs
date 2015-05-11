using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class Videos
    {
        [DataMember]
        public string king { get; set; }

        [DataMember]
        public string etag { get; set; }

        [DataContract]
        public class PageInfo
        {
            [DataMember]
            public int totalResults { get; set; }

            [DataMember]
            public int resultsPerPage { get; set; }
        }

        [DataMember]
        public PageInfo pageInfo { get; set; }

        [DataMember]
        public Video[] items { get; set; }
    }
}
