using System;
using System.IO;
using FatturaElettronica.Extensions;
using FatturaElettronica.Ordinaria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Extensions
{
    [TestClass]
    public class HtmlExtensionsTest
    {
        [TestMethod]
        public void WriteHtml()
        {
            var f = new FatturaOrdinaria();
            var outFile = Path.GetTempFileName();
            f.ReadXml("Samples/IT02182030391_32.xml");

            f.WriteHtml(outFile, "Samples/fatturaPA_v1.2.1.xsl");

            var bytes = File.ReadAllBytes(outFile);
            Assert.IsTrue(bytes.Length > 2048);
        }

        [TestMethod]
        public void WriteHtmlThrowsOnInvalidArguments()
        {
            var f = new FatturaOrdinaria();

            Assert.ThrowsException<ArgumentNullException>(() => f.WriteHtml(outPath: null, xslPath: "xslPath"));
            Assert.ThrowsException<ArgumentNullException>(() => f.WriteHtml(outPath: "fileName", xslPath: null));
        }
    }
}