using System.Linq;
using FatturaElettronica.Semplificata.FatturaElettronicaHeader;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class FatturaElettronicaHeaderValidator
        : BaseClass<FatturaElettronicaHeader,
            FatturaElettronica.Validators.Semplificata.FatturaElettronicaHeaderValidator>
    {
        [TestMethod]
        public void DatiTramissioneHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DatiTrasmissione, typeof(FatturaElettronica.Validators.Semplificata.DatiTrasmissioneValidator));
        }

        [TestMethod]
        public void CedentePrestatoreHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore,
                typeof(FatturaElettronica.Validators.Semplificata.CedentePrestatoreValidator));
        }

        [TestMethod]
        public void CessionarioCommittenteHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente,
                typeof(FatturaElettronica.Validators.Semplificata.CessionarioCommittenteValidator));
        }

        [TestMethod]
        public void SoggettoEmittenteIsOptional()
        {
            AssertOptional(x => x.SoggettoEmittente);
        }

        [TestMethod]
        public void SoggettoEmittenteOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<SoggettoEmittente>(x => x.SoggettoEmittente);
        }

        [TestMethod]
        public void HeaderValidateAgainstError00476()
        {
            Challenge.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA.IdPaese = "FR";
            Challenge.CedentePrestatore.IdFiscaleIVA.IdPaese = "FR";
            var result = Validator.Validate(Challenge);
            Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00476"));

            Challenge.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA.IdPaese = "IT";
            Challenge.CedentePrestatore.IdFiscaleIVA.IdPaese = "FR";
            result = Validator.Validate(Challenge);
            Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00476"));

            Challenge.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA.IdPaese = "FT";
            Challenge.CedentePrestatore.IdFiscaleIVA.IdPaese = "IT";
            result = Validator.Validate(Challenge);
            Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00476"));
            
            Challenge.CedentePrestatore.IdFiscaleIVA.IdPaese = "IT";
            Challenge.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA.IdPaese = null;
            result = Validator.Validate(Challenge);
            Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00476"));
        }
    }
}