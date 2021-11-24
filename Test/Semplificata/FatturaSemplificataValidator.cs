using FatturaElettronica.Semplificata;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class FatturaSemplificataValidator : BaseClass<FatturaSemplificata,
        FatturaElettronica.Validators.Semplificata.FatturaSemplificataValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            Validator = new();
            Challenge = new();
        }

        [TestMethod]
        public void FatturaElettronicaHeaderHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaHeader,
                typeof(FatturaElettronica.Validators.Semplificata.FatturaElettronicaHeaderValidator));
        }

        [TestMethod]
        public void FatturaElettronicaBodyHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaBody,
                typeof(FatturaElettronica.Validators.Semplificata.FatturaElettronicaBodyValidator));
        }
    }
}