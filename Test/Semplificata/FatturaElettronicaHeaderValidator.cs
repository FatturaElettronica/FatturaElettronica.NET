namespace Semplificata.Tests
{
    using FatturaElettronica.Semplificata.FatturaElettronicaHeader;
    using FatturaElettronica.Tabelle;
    using FluentValidation.TestHelper;
    using global::Tests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FatturaElettronicaHeaderValidator 
        : BaseClass<FatturaElettronicaHeader, FatturaElettronica.Validators.Semplificata.FatturaElettronicaHeaderValidator>
    {
        [TestMethod]
        public void DatiTramissioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiTrasmissione, typeof(FatturaElettronica.Validators.Semplificata.DatiTrasmissioneValidator));
        }
        [TestMethod]
        public void CedentePrestatoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore, typeof(FatturaElettronica.Validators.Semplificata.CedentePrestatoreValidator));
        }
        [TestMethod]
        public void CessionarioCommittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente, typeof(FatturaElettronica.Validators.Semplificata.CessionarioCommittenteValidator));
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
