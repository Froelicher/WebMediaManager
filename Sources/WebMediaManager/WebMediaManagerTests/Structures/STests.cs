using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManagerTests.Structures
{
    [DataContract]
    class STests
    {
        [DataMember]
        public int testInt { get; set; }

        [DataMember]
        public string testString { get; set; }

        [DataContract]
        public class TestInc
        {
            [DataMember]
            public string testIncString { get; set; }

            [DataMember]
            public long testIncLong { get; set; }
        }

        [DataMember]
        public TestInc testInc { get; set; }
    }
}
