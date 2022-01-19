using System;
using System.Text;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Core
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void JsonDeSerialize()
        {
            var base64String = "VGhpcyBpcyBhIHN0cmluZw==";
            var original = new TestMe { AString = "a string", ADate = DateTime.Now, ADecimal = 0.12345678m, ABool = true, AByteArray = Convert.FromBase64String(base64String) };
            original.SubTestMe.AString = "a sub string";
            original.SubTestMe.ADate = DateTime.Now.AddDays(+1);
            original.SubTestMe.ADecimal = 0.98765432m;
            original.SubTestMe.AByteArray = Convert.FromBase64String(base64String);
            var json = original.ToJson();

            Assert.IsFalse(json.Contains("XmlOptions"));

            var challenge = new TestMe();
            challenge.FromJson(new Utf8JsonReader(Encoding.UTF8.GetBytes(json)));

            Assert.AreEqual(original.AString, challenge.AString);
            Assert.AreEqual(original.ADate, challenge.ADate);
            Assert.AreEqual(original.ADecimal, challenge.ADecimal);
            CollectionAssert.AreEqual(original.AByteArray, challenge.AByteArray);
            Assert.AreEqual(original.SubTestMe.AString, challenge.SubTestMe.AString);
            Assert.AreEqual(original.SubTestMe.ADate, challenge.SubTestMe.ADate);
            Assert.AreEqual(original.SubTestMe.ABool, challenge.SubTestMe.ABool);
            Assert.AreEqual(original.SubTestMe.ADecimal, challenge.SubTestMe.ADecimal);
            CollectionAssert.AreEqual(original.SubTestMe.AByteArray, challenge.SubTestMe.AByteArray);
        }
    }
}