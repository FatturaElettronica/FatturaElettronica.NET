using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Validators;

namespace Tests
{
    [TestClass]
    public class FatturaElettronicaValidator : BaseClass<FatturaElettronica.FatturaElettronica, FatturaElettronica.Validators.FatturaElettronicaValidator>
    {
        [TestInitialize]
        public new void Init() 
        {
            validator = new FatturaElettronica.Validators.FatturaElettronicaValidator();
            challenge = FatturaElettronica.FatturaElettronica.CreateInstance(FatturaElettronica.Impostazioni.Instance.PubblicaAmministrazione);
        }

       [TestMethod]
       public void FatturaElettronicaHeaderHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaHeader, typeof(FatturaElettronica.Validators.FatturaElettronicaHeaderValidator));
            validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaBody, typeof(FatturaElettronica.Validators.FatturaElettronicaBodyValidator));
        }
    }
}
