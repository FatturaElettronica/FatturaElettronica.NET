namespace Tests
{
    using FatturaElettronica.Ordinaria.FatturaElettronicaHeader;
    using FatturaElettronica.Tabelle;
    using FluentValidation.TestHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FatturaElettronicaHeaderValidator
        : BaseClass<FatturaElettronicaHeader, FatturaElettronica.Validators.FatturaElettronicaHeaderValidator>
    {
        [TestMethod]
        public void DatiTramissioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiTrasmissione, typeof(FatturaElettronica.Validators.DatiTrasmissioneValidator));
        }
        [TestMethod]
        public void CedentePrestatoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore, typeof(FatturaElettronica.Validators.CedentePrestatoreValidator));
        }
        [TestMethod]
        public void RappresentanteFiscaleHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.Rappresentante, typeof(FatturaElettronica.Validators.RappresentanteFiscaleValidator));
        }
        [TestMethod]
        public void CessionarioCommittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente, typeof(FatturaElettronica.Validators.CessionarioCommittenteValidator));
        }
        [TestMethod]
        public void TerzoIntermediarioHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.TerzoIntermediarioOSoggettoEmittente, typeof(FatturaElettronica.Validators.TerzoIntermediarioOSoggettoEmittenteValidator));
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
