using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.DatiTrasmissione;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria;
using FatturaElettronica.Validators;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiTrasmissioneValidator
        : BaseClass<DatiTrasmissione, FatturaElettronica.Validators.DatiTrasmissioneValidator>
    {
        [TestMethod]
        public void IdTrasmittenteHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.IdTrasmittente,
                typeof(IdTrasmittenteValidator));
        }

        [TestMethod]
        public void ProgressivoInvioIsRequired()
        {
            AssertRequired(x => x.ProgressivoInvio);
        }

        [TestMethod]
        public void ContattiTrasmittenteHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(x => x.ContattiTrasmittente,
                typeof(FatturaElettronica.Validators.ContattiTrasmittenteValidator));
        }

        [TestMethod]
        public void ProgressivoInvioMinMaxLength()
        {
            AssertMinMaxLength(x => x.ProgressivoInvio, 1, 10);
        }

        [TestMethod]
        public void ProgressivoInvioMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.ProgressivoInvio);
        }

        [TestMethod]
        public void FormatoTrasmissioneIsRequired()
        {
            AssertRequired(x => x.FormatoTrasmissione);
        }

        [TestMethod]
        public void FormatoTrasmissioneOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<FormatoTrasmissione>(x => x.FormatoTrasmissione, expectedErrorCode: "00428");
        }

        [TestMethod]
        public void CodiceDestinatarioIsRequired()
        {
            AssertRequired(x => x.CodiceDestinatario);
        }

        [TestMethod]
        public void CodiceDestinatarioMustBeValid()
        {
            Challenge.CodiceDestinatario = "hello";
            Validator.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario, Challenge);
            Challenge.CodiceDestinatario = "Subm70N";
            Validator.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario, Challenge);
            Challenge.CodiceDestinatario = "Sub-70N";
            Validator.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario, Challenge);
            Challenge.CodiceDestinatario = "SUBM70N";
            Validator.ShouldNotHaveValidationErrorFor(x => x.CodiceDestinatario, Challenge);
        }

        [TestMethod]
        public void CodiceDestinatarioWhenFormatoTrasmissioneHasValueFPA12()
        {
            // Quando FormatoTrasmissione = FPA12 ProgressivioInvio.Lenght = 6.
            Challenge.FormatoTrasmissione = Defaults.FormatoTrasmissione.PubblicaAmministrazione;
            AssertLength(x => x.CodiceDestinatario, 6, expectedErrorCode: "00427", filler: 'X');
        }

        [TestMethod]
        public void CodiceDestinatarioWhenFormatoTrasmissioneHasValueFPR12()
        {
            // Quando FormatoTrasmissione = FPR12 ProgressivioInvio.Lenght = 7.
            Challenge.FormatoTrasmissione = Defaults.FormatoTrasmissione.Privati;
            AssertLength(x => x.CodiceDestinatario, 7, expectedErrorCode: "00427", filler: 'X');
        }

        [TestMethod]
        public void PECDestinatarioMinMaxLength()
        {
            Challenge.CodiceDestinatario = new string('0', 7);
            AssertMinMaxLength(x => x.PECDestinatario, 7, 256);
        }
    }
}