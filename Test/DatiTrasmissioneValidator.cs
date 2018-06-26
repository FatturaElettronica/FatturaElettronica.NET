using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione;
using FatturaElettronica.Tabelle;

namespace Tests
{
    [TestClass]
    public class DatiTrasmissioneValidator 
        : BaseClass<DatiTrasmissione, FatturaElettronica.Validators.DatiTrasmissioneValidator>
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
        public void ContattiTrasmittenteHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(x => x.ContattiTrasmittente, typeof(FatturaElettronica.Validators.ContattiTrasmittenteValidator));
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
            AssertOnlyAcceptsTableValues<FormatoTrasmissione>(x => x.FormatoTrasmissione, expectedErrorCode:"00428");
        }
        [TestMethod]
        public void CodiceDestinatarioIsRequired()
        {
            AssertRequired(x => x.CodiceDestinatario);
        }
        [TestMethod]
        public void CodiceDestinatarioWhenFormatoTrasmissioneHasValueFPA12()
        {
            // Quando FormatoTrasmissione = FPA12 ProgressivioInvio.Lenght = 6.
            challenge.FormatoTrasmissione = FatturaElettronica.Impostazioni.FormatoTrasmissione.PubblicaAmministrazione;
            AssertLength(x => x.CodiceDestinatario, 6, expectedErrorCode:"00427");
        }
        [TestMethod]
        public void CodiceDestinatarioWhenFormatoTrasmissioneHasValueFPR12()
        {
            // Quando FormatoTrasmissione = FPR12 ProgressivioInvio.Lenght = 7.
            challenge.FormatoTrasmissione = FatturaElettronica.Impostazioni.FormatoTrasmissione.Privati;
            AssertLength(x => x.CodiceDestinatario, 7, expectedErrorCode:"00427");
        }
        [TestMethod]
        public void PECDestinatarioMinMaxLength()
        {
            challenge.CodiceDestinatario = new string('0', 7);
            AssertMinMaxLength(x => x.PECDestinatario, 7, 256);
        }
    }
}
