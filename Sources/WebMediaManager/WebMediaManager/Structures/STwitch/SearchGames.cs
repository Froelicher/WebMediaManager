﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class SearchGames
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
        public Game[] games { get; set; }

    }
}
