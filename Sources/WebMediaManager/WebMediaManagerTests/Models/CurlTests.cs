using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMediaManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMediaManagerTests.Structures;
using System.IO;
namespace WebMediaManager.Models.Tests
{
    [TestClass()]
    public class CurlTests
    {
        [TestMethod()]
        public void DeserializeTest()
        {
            //Open file test
            string testJson = File.ReadAllText("../../JsonFileTest.txt");
            STests tests = new STests();

            //Create stream from string
           
            using(Stream stream = Curl.GenerateStreamFromString(testJson))
            {
                tests = Curl.Deserialize<STests>(stream);
            }

            //Deserialize
            Assert.AreEqual(tests.testInt, 1234);
            Assert.AreEqual(tests.testString, "test string with int 192");
            Assert.AreEqual(tests.testInc.testIncString, "inc string test");
            Assert.AreEqual(tests.testInc.testIncLong, 23993945);
        }
    }
}
