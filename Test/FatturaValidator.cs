namespace Tests
{
    using FatturaElettronica.Ordinaria;
    using FluentValidation.TestHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FatturaValidator : BaseClass<Fattura, FatturaElettronica.Validators.FatturaValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            validator = new FatturaElettronica.Validators.FatturaValidator();
            challenge = new Fattura();
        }

        [TestMethod]
        public void FatturaElettronicaHeaderHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaHeader, typeof(FatturaElettronica.Validators.FatturaElettronicaHeaderValidator));
        }
        [TestMethod]
        public void FatturaElettronicaBodyHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaBody, typeof(FatturaElettronica.Validators.FatturaElettronicaBodyValidator));
        }
    }
}
