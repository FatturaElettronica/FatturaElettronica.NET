using System.Linq;
using FatturaElettronica.Ordinaria.FatturaElettronicaHeader;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class FatturaElettronicaHeaderValidator
        : BaseClass<FatturaElettronicaHeader, FatturaElettronica.Validators.FatturaElettronicaHeaderValidator>
    {
        [TestMethod]
        public void DatiTramissioneHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DatiTrasmissione, typeof(FatturaElettronica.Validators.DatiTrasmissioneValidator));
        }

        [TestMethod]
        public void CedentePrestatoreHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore, typeof(FatturaElettronica.Validators.CedentePrestatoreValidator));
        }

        [TestMethod]
        public void RappresentanteFiscaleHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.Rappresentante, typeof(FatturaElettronica.Validators.RappresentanteFiscaleValidator));
        }

        [TestMethod]
        public void CessionarioCommittenteHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente, typeof(FatturaElettronica.Validators.CessionarioCommittenteValidator));
        }

        [TestMethod]
        public void TerzoIntermediarioHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.TerzoIntermediarioOSoggettoEmittente,
                typeof(FatturaElettronica.Validators.TerzoIntermediarioOSoggettoEmittenteValidator));
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
        public void HeaderValidateAgainstError00313()
        {
            Challenge.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = "IT";
            Challenge.DatiTrasmissione.CodiceDestinatario = "XXXXXXX";
            var result = Validator.Validate(Challenge);
            Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00313"));

            Challenge.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = "FR";
            result = Validator.Validate(Challenge);
            Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00313"));

            Challenge.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = "IT";
            Challenge.DatiTrasmissione.CodiceDestinatario = "0123456";
            result = Validator.Validate(Challenge);
            Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00313"));
        }

        [TestMethod]
        public void HeaderValidateAgainstError00476()
        {
            Challenge.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = "FR";
            Challenge.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese = "FR";
            var result = Validator.Validate(Challenge);
            Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00476"));

            Challenge.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = "IT";
            Challenge.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese = "FR";
            result = Validator.Validate(Challenge);
            Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00476"));

            Challenge.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = "FT";
            Challenge.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese = "IT";
            result = Validator.Validate(Challenge);
            Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00476"));
        }
    }
}