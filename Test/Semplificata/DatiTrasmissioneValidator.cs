using FatturaElettronica.Semplificata.FatturaElettronicaHeader.DatiTrasmissione;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class DatiTrasmissioneValidator
        : BaseClass<DatiTrasmissione, FatturaElettronica.Validators.Semplificata.DatiTrasmissioneValidator>
    {
        [TestMethod]
        public void IdTrasmittenteHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.IdTrasmittente,
                typeof(Validators.IdTrasmittenteValidator));
        }

        [TestMethod]
        public void ProgressivoInvioIsRequired()
        {
            AssertRequired(x => x.ProgressivoInvio);
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
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario);

            Challenge.CodiceDestinatario = "Subm70N";
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario);

            Challenge.CodiceDestinatario = "Sub-70N";
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.CodiceDestinatario);

            Challenge.CodiceDestinatario = "SUBM70N";
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.CodiceDestinatario);
        }

        [TestMethod]
        public void CodiceDestinatarioWhenFormatoTrasmissioneHasValueFSM10()
        {
            // Quando FormatoTrasmissione = FSM10 ProgressivioInvio.Lenght = 7.
            Challenge.FormatoTrasmissione = Defaults.FormatoTrasmissione.Semplificata;
            AssertLength(x => x.CodiceDestinatario, 7, expectedErrorCode: "00311", filler: 'X');
        }

        [TestMethod]
        public void PECDestinatarioIsOptional()
        {
            AssertOptional(x => x.PECDestinatario);
        }

        [TestMethod]
        public void PECDestinatarioMustBeValid()
        {
            Challenge.PECDestinatario = "not really";
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.PECDestinatario);
            
            Challenge.PECDestinatario = "maybe@we.can";
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PECDestinatario);
        }
    }
}