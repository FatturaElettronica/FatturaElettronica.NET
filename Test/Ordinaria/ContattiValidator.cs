using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation.TestHelper;
using FluentValidation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class ContattiValidator
        : BaseClass<Contatti, FatturaElettronica.Validators.ContattiValidator>
    {
        [TestMethod]
        public void TelefonoIsOptional()
        {
            AssertOptional(x => x.Telefono);
        }

        [TestMethod]
        public void TelefonoMinMaxLength()
        {
            AssertMinMaxLength(x => x.Telefono, 5, 12);
        }

        [TestMethod]
        public void FaxIsOptional()
        {
            AssertOptional(x => x.Fax);
        }

        [TestMethod]
        public void FaxMinMaxLength()
        {
            AssertMinMaxLength(x => x.Fax, 5, 12);
        }

        [TestMethod]
        public void EmailIsOptional()
        {
            AssertOptional(x => x.Email);
        }

        [TestMethod]
        public void EmailMustBeValid()
        {
            Challenge.Email = "not really";
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Email);
            
            Challenge.Email = "not@really";
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Email);
            
            Challenge.Email = "maybe@we.can";
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }
    }
}