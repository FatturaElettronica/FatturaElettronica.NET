using FatturaElettronica.Semplificata;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Semplificata.Tests
{
    [TestClass]
    public class FatturaSemplificataValidator : BaseClass<FatturaSemplificata, FatturaElettronica.Validators.Semplificata.FatturaSemplificataValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            validator = new FatturaElettronica.Validators.Semplificata.FatturaSemplificataValidator();
            challenge = new FatturaSemplificata();
        }

        [TestMethod]
        public void FatturaElettronicaHeaderHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaHeader, typeof(FatturaElettronica.Validators.Semplificata.FatturaElettronicaHeaderValidator));
        }
        [TestMethod]
        public void FatturaElettronicaBodyHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaBody, typeof(FatturaElettronica.Validators.Semplificata.FatturaElettronicaBodyValidator));
        }
    }
}
