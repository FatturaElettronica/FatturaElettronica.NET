using System;
using System.IO;
using FatturaElettronica.Core;
using FatturaElettronica.Ordinaria;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using DefaultValueHandling = FatturaElettronica.Core.DefaultValueHandling;

namespace FatturaElettronica.Test.Core
{
    public class MyFatturaOrdinaria : FatturaOrdinaria
    {
        public override string ToJson(JsonOptions options)
        {
            // your code here.
            return base.ToJson(options);
        }
    }

    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void DefaultValueHandlingOptions()
        {
            var test = new TestMe();

            var json = test.ToJson();
            Assert.IsFalse(json.Contains("AInteger"));

            json = test.ToJson(new() { DefaultValueHandling = DefaultValueHandling.Include });
            Assert.IsTrue(json.Contains("AInteger"));
        }

        [TestMethod]
        public void JsonDeSerialize()
        {
            var base64String = "VGhpcyBpcyBhIHN0cmluZw==";
            var original = new TestMe
            {
                AInteger = 0,
                AString = "a string",
                ADate = DateTime.Now,
                ADecimal = 0.12345678m,
                AByteArray = Convert.FromBase64String(base64String),
                SubTestMe =
                {
                    AString = "a sub string",
                    ADate = DateTime.Now.AddDays(+1),
                    ADecimal = 0.98765432m,
                    AByteArray = Convert.FromBase64String(base64String)
                }
            };

            var json = original.ToJson();
            Assert.IsFalse(json.Contains("XmlOptions"));


            var challenge = new TestMe();
            challenge.FromJson(new JsonTextReader(new StringReader(json)));

            Assert.AreEqual(original.AString, challenge.AString);
            Assert.AreEqual(original.AString, challenge.AString);
            Assert.AreEqual(original.ADate, challenge.ADate);
            Assert.AreEqual(original.ADecimal, challenge.ADecimal);
            Assert.AreEqual(0, challenge.AInteger);
            CollectionAssert.AreEqual(original.AByteArray, challenge.AByteArray);
            Assert.AreEqual(original.SubTestMe.AString, challenge.SubTestMe.AString);
            Assert.AreEqual(original.SubTestMe.ADate, challenge.SubTestMe.ADate);
            Assert.AreEqual(original.SubTestMe.ADecimal, challenge.SubTestMe.ADecimal);
            Assert.AreEqual(original.SubTestMe.AInteger, challenge.SubTestMe.AInteger);
            CollectionAssert.AreEqual(original.SubTestMe.AByteArray, challenge.SubTestMe.AByteArray);
        }
    }
}