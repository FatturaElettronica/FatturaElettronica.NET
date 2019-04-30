using FatturaElettronica.Ordinaria;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ordinaria.Tests
{
    [TestClass]
    public class FatturaValidator : BaseClass<FatturaOrdinaria, FatturaElettronica.Validators.FatturaOrdinariaValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            validator = new FatturaElettronica.Validators.FatturaOrdinariaValidator();
            challenge = new FatturaOrdinaria();
        }

        [TestMethod]
        [System.Obsolete]
        public void FatturaElettronicaHeaderHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaHeader, typeof(FatturaElettronica.Validators.FatturaElettronicaHeaderValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void FatturaElettronicaBodyHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaBody, typeof(FatturaElettronica.Validators.FatturaElettronicaBodyValidator));
        }
    }
}
