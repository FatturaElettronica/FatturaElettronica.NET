using System;
using FatturaElettronica.Extensions;
using FatturaElettronica.Extensions.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Extensions
{
    [TestClass]
    public class FilenameGeneratorTest
    {
        [TestMethod]
        public void Initialize()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new FatturaElettronicaFileNameGenerator(null));
            Assert.ThrowsException<ArgumentException>(() => new FatturaElettronicaFileNameGenerator(new()),
                ErrorMessages.IdFiscaleIsMissing);
            Assert.ThrowsException<ArgumentException>(
                () => new FatturaElettronicaFileNameGenerator(new() {IdPaese = "I"}),
                ErrorMessages.IdPaeseIsWrongOrMissing);
            Assert.ThrowsException<ArgumentException>(
                () => new FatturaElettronicaFileNameGenerator(new() {IdPaese = "IT"}),
                ErrorMessages.IdCodiceIsMissing);
            var filename =
                new FatturaElettronicaFileNameGenerator(new() {IdPaese = "IT", IdCodice = "0123456789"});
            Assert.IsTrue(filename != null);
        }

        [TestMethod]
        public void ConvertIntegerToFilename()
        {
            var filenameGenerator =
                new FatturaElettronicaFileNameGenerator(new() {IdPaese = "IT", IdCodice = "0123456789"});
            var filename = filenameGenerator.GetNextFileName(11);
            Assert.IsTrue(filename == "IT0123456789_0000C.xml");
            Assert.AreEqual(12, filenameGenerator.CurrentIndex);
        }

        [TestMethod]
        public void ConvertStringToFilename()
        {
            var filenameGenerator =
                new FatturaElettronicaFileNameGenerator(new() {IdPaese = "IT", IdCodice = "0123456789"});
            var filename = filenameGenerator.GetNextFileName("0000C");
            Assert.IsTrue(filename == "IT0123456789_0000D.xml");
            Assert.AreEqual(13, filenameGenerator.CurrentIndex);
        }

        [TestMethod]
        public void ConvertIntegerToFilenameSigned()
        {
            var filenameGenerator = new FatturaElettronicaFileNameGenerator(
                new() {IdPaese = "IT", IdCodice = "0123456789"},
                FatturaElettronicaFileNameExtensionType.Signed);
            var filename = filenameGenerator.GetNextFileName(11);
            Assert.IsTrue(filename == "IT0123456789_0000C.xml.p7m");
            Assert.AreEqual(12, filenameGenerator.CurrentIndex);
        }

        [TestMethod]
        public void ConvertStringToFilenameSigned()
        {
            var filenameGenerator = new FatturaElettronicaFileNameGenerator(
                new() {IdPaese = "IT", IdCodice = "0123456789"},
                FatturaElettronicaFileNameExtensionType.Signed);
            var filename = filenameGenerator.GetNextFileName("0000C");
            Assert.IsTrue(filename == "IT0123456789_0000D.xml.p7m");
            Assert.AreEqual(13, filenameGenerator.CurrentIndex);
        }

        [TestMethod]
        public void ConvertIntegerToFilename2Char()
        {
            var filenameGenerator =
                new FatturaElettronicaFileNameGenerator(new() {IdPaese = "IT", IdCodice = "0123456789"});
            var filename = filenameGenerator.GetNextFileName(36);
            Assert.IsTrue(filename == "IT0123456789_00011.xml");
            Assert.AreEqual(37, filenameGenerator.CurrentIndex);
        }

        [TestMethod]
        public void LastBillingNumberLength()
        {
            var filenameGenerator =
                new FatturaElettronicaFileNameGenerator(new() {IdPaese = "IT", IdCodice = "0123456789"});
            Assert.ThrowsException<ArgumentException>(() => filenameGenerator.GetNextFileName("123456"),
                ErrorMessages.LastBillingNumberIsTooLong);
        }
    }
}