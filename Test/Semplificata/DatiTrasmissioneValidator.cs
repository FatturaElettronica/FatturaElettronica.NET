using FatturaElettronica.Semplificata.FatturaElettronicaHeader.DatiTrasmissione;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Semplificata.Tests
{
   [TestClass]
    public class DatiTrasmissioneValidator
        : BaseClass<DatiTrasmissione, FatturaElettronica.Validators.Semplificata.DatiTrasmissioneValidator>
    {
        [TestMethod]
        public void IdTrasmittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdTrasmittente, typeof(FatturaElettronica.Validators.IdTrasmittenteValidator));
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
        public void CodiceDestinatarioWhenFormatoTrasmissioneHasValueFPR12()
        {
            // Quando FormatoTrasmissione = FSM10 ProgressivioInvio.Lenght = 7.
            challenge.FormatoTrasmissione = FatturaElettronica.Defaults.FormatoTrasmissione.Semplificata;
            AssertLength(x => x.CodiceDestinatario, 7, expectedErrorCode: "00311");
        }
        [TestMethod]
        public void PECDestinatarioMinMaxLength()
        {
            challenge.CodiceDestinatario = new string('0', 7);
            AssertMinMaxLength(x => x.PECDestinatario, 7, 256);
        }
    }
}
