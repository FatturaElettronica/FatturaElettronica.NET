using System;
using System.Collections.Generic;
using System.Text;
using FatturaElettronica.Filename;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test
{
    [TestClass]
    public class FatturaElettronicaFilenameTest
    {
        [TestMethod]
        public void Initialize()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new FatturaElettronicaFilename(null));
            Assert.ThrowsException<ArgumentException>(() => new FatturaElettronicaFilename(new Common.IdFiscaleIVA()));
            Assert.ThrowsException<ArgumentException>(() => new FatturaElettronicaFilename(new Common.IdFiscaleIVA() { IdPaese = "I" }));
            Assert.ThrowsException<ArgumentException>(() => new FatturaElettronicaFilename(new Common.IdFiscaleIVA() { IdPaese = "IT" }));
            var filename = new FatturaElettronicaFilename(new Common.IdFiscaleIVA() { IdPaese = "IT", IdCodice = "0123456789"});
            Assert.IsTrue(filename != null);
        }

        [TestMethod]
        public void ConvertIntegerToFilename()
        {
            var filenameGenerator = new FatturaElettronicaFilename(new Common.IdFiscaleIVA() { IdPaese = "IT", IdCodice = "0123456789" });
            var filename = filenameGenerator.FileName(11);
            Assert.IsTrue(filename == "IT0123456789_C.xml");
        }

        [TestMethod]
        public void ConvertStringToFilename()
        {
            var filenameGenerator = new FatturaElettronicaFilename(new Common.IdFiscaleIVA() { IdPaese = "IT", IdCodice = "0123456789" });
            var filename = filenameGenerator.FileName("C");
            Assert.IsTrue(filename == "IT0123456789_D.xml");
        }

        [TestMethod]
        public void ConvertIntegerToFilename2Char()
        {
            var filenameGenerator = new FatturaElettronicaFilename(new Common.IdFiscaleIVA() { IdPaese = "IT", IdCodice = "0123456789" });
            var filename = filenameGenerator.FileName(62);
            Assert.IsTrue(filename == "IT0123456789_11.xml");
        }
    }
}
