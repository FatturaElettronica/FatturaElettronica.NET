using FluentValidation.TestHelper;
using FatturaElettronica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione;

namespace Tests
{
    [TestClass]
    public class DatiTrasmissioneValidator
    {
        private FatturaElettronica.Validators.DatiTrasmissioneValidator validator;
        private DatiTrasmissione challenge;

        [TestInitialize]
        public void Init()
        {
            validator = new FatturaElettronica.Validators.DatiTrasmissioneValidator();
            challenge = new DatiTrasmissione();
        }

        [TestMethod]
        public void IdTrasmittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdTrasmittente, typeof(FatturaElettronica.Validators.IdTrasmittenteValidator));
        }
        [TestMethod]
        public void ProgressivoInvioCannotBeEmpty()
        {
            challenge.ProgressivoInvio = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.ProgressivoInvio, challenge);
        }
        [TestMethod]
        public void ContattiTrasmittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.ContattiTrasmittente, typeof(FatturaElettronica.Validators.ContattiTrasmittenteValidator));
        }
        [TestMethod]
        public void ProgressivoInvioMinMaxLength()
        {
            challenge.ProgressivoInvio = "";
            validator.ShouldHaveValidationErrorFor(x => x.ProgressivoInvio, challenge);
            challenge.ProgressivoInvio = new string('x', 11);
            validator.ShouldHaveValidationErrorFor(x => x.ProgressivoInvio, challenge);
            challenge.ProgressivoInvio = "1";
            validator.ShouldNotHaveValidationErrorFor(x => x.ProgressivoInvio, challenge);
        }
        [TestMethod]
        public void FormatoTrasmissioneCannotBeEmpty()
        {
            challenge.FormatoTrasmissione = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.FormatoTrasmissione, challenge);
        }
        [TestMethod]
        public void FormatoTrasmissioneCanOnlyAcceptDomainValues()
        {
            challenge.FormatoTrasmissione = "";
            validator.ShouldHaveValidationErrorFor(x => x.FormatoTrasmissione, challenge);
            challenge.FormatoTrasmissione = "XX";
            validator.ShouldHaveValidationErrorFor(x => x.FormatoTrasmissione, challenge);
            challenge.FormatoTrasmissione = "FPA12";
            validator.ShouldNotHaveValidationErrorFor(x => x.FormatoTrasmissione, challenge);
            challenge.FormatoTrasmissione = "FPR12";
            validator.ShouldNotHaveValidationErrorFor(x => x.FormatoTrasmissione, challenge);
        }
        [TestMethod]
        public void CodiceDestinatarioWhenFormatoTrasmissioneHasValueFPA12()
        {
            // Quando FormatoTrasmissione = FPA12 ProgressivioInvio.Lenght = 6.
            challenge.FormatoTrasmissione = FatturaElettronica.Impostazioni.FormatoTrasmissione.PubblicaAmministrazione;
            challenge.CodiceDestinatario = null;
            validator.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario, challenge);
            challenge.CodiceDestinatario = new string('x', 6);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceDestinatario, challenge);
            challenge.CodiceDestinatario = new string('x', 1);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario, challenge);
            challenge.CodiceDestinatario = new string('x', 7);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario, challenge);
        }
        [TestMethod]
        public void CodiceDestinatarioWhenFormatoTrasmissioneHasValueFPR12()
        {

            // Quando FormatoTrasmissione = FPR12 ProgressivioInvio.Lenght = 7.
            challenge.FormatoTrasmissione = FatturaElettronica.Impostazioni.FormatoTrasmissione.Privati;
            challenge.CodiceDestinatario = new string('x', 7);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceDestinatario, challenge);
            challenge.CodiceDestinatario = new string('x', 1);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario, challenge);
            challenge.CodiceDestinatario = new string('x', 6);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario, challenge);
        }
        [TestMethod]
        public void PECDestinatarioWithCodiceDestinatarioHasValue0000000()
        {
            challenge.CodiceDestinatario = new string('0', 7);

            challenge.PECDestinatario = null;
            validator.ShouldHaveValidationErrorFor(x => x.PECDestinatario, challenge);
            challenge.PECDestinatario = new string('x', 6);
            validator.ShouldHaveValidationErrorFor(x => x.PECDestinatario, challenge);
            challenge.PECDestinatario = new string('x', 257);
            validator.ShouldHaveValidationErrorFor(x => x.PECDestinatario, challenge);
            challenge.PECDestinatario = new string('x', 7);
            validator.ShouldNotHaveValidationErrorFor(x => x.PECDestinatario, challenge);
            challenge.PECDestinatario = new string('x', 256);
            validator.ShouldNotHaveValidationErrorFor(x => x.PECDestinatario, challenge);
        }
        [TestMethod]
        public void PECDestinatarioWithCodiceDestinatarioHasNotValue0000000()
        {
            challenge.CodiceDestinatario = "1234567";

            challenge.PECDestinatario = "whatever";
            validator.ShouldHaveValidationErrorFor(x => x.PECDestinatario, challenge);
            challenge.PECDestinatario = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.PECDestinatario, challenge);
        }
    }
}
