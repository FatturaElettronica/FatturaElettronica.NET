using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Core
{
    [TestClass]
    public class DeSerialize
    {
        [TestMethod]
        public void XmlDeSerialize()
        {
            var original = new TestMe { AString = "a string", ADate = DateTime.Now, ADecimal = 0.12345678m };
            original.SubTestMe.AString = "a sub string";
            original.SubTestMe.ADate = DateTime.Now.AddDays(+1);
            original.SubTestMe.ADecimal = 0.98765432m;

           var tempFile = "test.xml";
            using (var w = XmlWriter.Create(tempFile))
            {
                original.WriteXml(w);
            }

            var challenge = new TestMe();
            using (var r = XmlReader.Create(tempFile))
            {
                challenge.ReadXml(r);
            }

            Assert.AreEqual(original.AString, challenge.AString);
            Assert.AreEqual(original.ADate.Date, challenge.ADate);
            Assert.AreEqual(original.ADecimal, challenge.ADecimal);
            Assert.AreEqual(original.SubTestMe.AString, challenge.SubTestMe.AString);
            Assert.AreEqual(original.SubTestMe.ADate.Date, challenge.SubTestMe.ADate);
            Assert.AreEqual(original.SubTestMe.ADate.Date, challenge.SubTestMe.ADate);
            Assert.AreEqual(original.SubTestMe.ADecimal, challenge.SubTestMe.ADecimal);
        }
    }
}
