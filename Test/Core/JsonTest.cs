using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace FatturaElettronica.Test.Core
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void JsonDeSerialize()
        {
            var original = new TestMe { AString = "a string", ADate = DateTime.Now, ADecimal = 0.12345678m };
            original.SubTestMe.AString = "a sub string";
            original.SubTestMe.ADate = DateTime.Now.AddDays(+1);
            original.SubTestMe.ADecimal = 0.98765432m;
            var json = original.ToJson();

            Assert.IsFalse(json.Contains("XmlOptions"));

            var challenge = new TestMe();
            challenge.FromJson(new JsonTextReader(new StringReader(json)));

            Assert.AreEqual(original.AString, challenge.AString);
            Assert.AreEqual(original.ADate, challenge.ADate);
            Assert.AreEqual(original.ADecimal, challenge.ADecimal);
            Assert.AreEqual(original.SubTestMe.AString, challenge.SubTestMe.AString);
            Assert.AreEqual(original.SubTestMe.ADate, challenge.SubTestMe.ADate);
            Assert.AreEqual(original.SubTestMe.ADecimal, challenge.SubTestMe.ADecimal);
        }
    }
}
