using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.Allegati;

namespace Tests
{
    [TestClass]
    public class AllegatiValidator: BaseClass<Allegati, FatturaElettronica.Validators.AllegatiValidator>
    {
        [TestMethod]
        public void NomeAttachmentCannotBeEmpty()
        {
            challenge.NomeAttachment = null;
            validator.ShouldHaveValidationErrorFor(x => x.NomeAttachment, challenge);
            challenge.NomeAttachment = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.NomeAttachment, challenge);
        }
        [TestMethod]
        public void NomeAttachmentMinMaxLength()
        {
            challenge.NomeAttachment = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.NomeAttachment, challenge);
            challenge.NomeAttachment = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.NomeAttachment, challenge);
            challenge.NomeAttachment = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.NomeAttachment, challenge);
        }
        [TestMethod]
        public void AlgoritmoCompressioneCanBeEmpty()
        {
            challenge.AlgoritmoCompressione = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.AlgoritmoCompressione, challenge);
            challenge.AlgoritmoCompressione = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.AlgoritmoCompressione, challenge);
        }
        [TestMethod]
        public void AlgoritmoCompressioneMinMaxLength()
        {
            challenge.AlgoritmoCompressione = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.AlgoritmoCompressione, challenge);
            challenge.AlgoritmoCompressione = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.AlgoritmoCompressione, challenge);
            challenge.AlgoritmoCompressione = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.AlgoritmoCompressione, challenge);
        }
        [TestMethod]
        public void FormatoAttachmentCanBeEmpty()
        {
            challenge.FormatoAttachment = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.FormatoAttachment, challenge);
            challenge.FormatoAttachment = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.FormatoAttachment, challenge);
        }
        [TestMethod]
        public void FormatoAttachmentMinMaxLength()
        {
            challenge.FormatoAttachment = new string('x', 11);
            validator.ShouldHaveValidationErrorFor(x => x.FormatoAttachment, challenge);
            challenge.FormatoAttachment = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.FormatoAttachment, challenge);
            challenge.FormatoAttachment = new string('x', 10);
            validator.ShouldNotHaveValidationErrorFor(x => x.FormatoAttachment, challenge);
        }
        [TestMethod]
        public void DescrizioneAttachmentCanBeEmpty()
        {
            challenge.DescrizioneAttachment = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.DescrizioneAttachment, challenge);
            challenge.DescrizioneAttachment = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.DescrizioneAttachment, challenge);
        }
        [TestMethod]
        public void DescrizioneAttachmentMinMaxLength()
        {
            challenge.DescrizioneAttachment = new string('x', 101);
            validator.ShouldHaveValidationErrorFor(x => x.DescrizioneAttachment, challenge);
            challenge.DescrizioneAttachment = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.DescrizioneAttachment, challenge);
            challenge.DescrizioneAttachment = new string('x', 100);
            validator.ShouldNotHaveValidationErrorFor(x => x.DescrizioneAttachment, challenge);
        }
        [TestMethod]
        public void AttachmentCannotBeEmpty()
        {
            challenge.Attachment = null;
            validator.ShouldHaveValidationErrorFor(x => x.Attachment, challenge);
        }
    }
}
