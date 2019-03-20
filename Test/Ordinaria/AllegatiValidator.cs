using FatturaElettronica.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Ordinaria.Tests
{
    [TestClass]
    public class AllegatiValidator
        : BaseClass<Allegati, FatturaElettronica.Validators.AllegatiValidator>
    {
        [TestMethod]
        public void NomeAttachmentIsRequired()
        {
            AssertRequired(x => x.NomeAttachment);
        }
        [TestMethod]
        public void NomeAttachmentMinMaxLength()
        {
            AssertMinMaxLength(x => x.NomeAttachment, 1, 60);
        }
        [TestMethod]
        public void NomeAttachmentMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.NomeAttachment);
        }
        [TestMethod]
        public void AlgoritmoCompressioneIsOptional()
        {
            AssertOptional(x => x.AlgoritmoCompressione);
        }
        [TestMethod]
        public void AlgoritmoCompressioneMinMaxLength()
        {
            AssertMinMaxLength(x => x.AlgoritmoCompressione, 1, 60);
        }
        [TestMethod]
        public void AlgoritmoCompressioneMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.AlgoritmoCompressione);
        }
        [TestMethod]
        public void FormatoAttachmentIsOptional()
        {
            AssertOptional(x => x.FormatoAttachment);
        }
        [TestMethod]
        public void FormatoAttachmentMinMaxLength()
        {
            AssertMinMaxLength(x => x.FormatoAttachment, 1, 10);
        }
        [TestMethod]
        public void FormatoAttachmentMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.FormatoAttachment);
        }
        [TestMethod]
        public void DescrizioneAttachmentIsOptional()
        {
            AssertOptional(x => x.DescrizioneAttachment);
        }
        [TestMethod]
        public void DescrizioneAttachmentMinMaxLength()
        {
            AssertMinMaxLength(x => x.DescrizioneAttachment, 1, 100);
        }
        [TestMethod]
        public void DescrizioneAttachmentMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.DescrizioneAttachment);
        }
        [TestMethod]
        public void AttachmentIsRequired()
        {
            AssertRequired(x => x.Attachment);
        }
    }
}
