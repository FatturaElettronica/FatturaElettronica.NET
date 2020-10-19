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
    }
}