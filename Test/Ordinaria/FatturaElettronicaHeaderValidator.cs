using FatturaElettronica.Ordinaria.FatturaElettronicaHeader;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ordinaria.Tests
{
    [TestClass]
    public class FatturaElettronicaHeaderValidator
         : BaseClass<FatturaElettronicaHeader, FatturaElettronica.Validators.FatturaElettronicaHeaderValidator>
    {
        [TestMethod]
        [System.Obsolete]
        public void DatiTramissioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiTrasmissione, typeof(FatturaElettronica.Validators.DatiTrasmissioneValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void CedentePrestatoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore, typeof(FatturaElettronica.Validators.CedentePrestatoreValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void RappresentanteFiscaleHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.Rappresentante, typeof(FatturaElettronica.Validators.RappresentanteFiscaleValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void CessionarioCommittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente, typeof(FatturaElettronica.Validators.CessionarioCommittenteValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void TerzoIntermediarioHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
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
