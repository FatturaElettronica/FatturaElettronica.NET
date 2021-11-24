using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.DatiTrasmissione;
using FatturaElettronica.Validators;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class ContattiTrasmittenteValidator
        : BaseClass<ContattiTrasmittente, FatturaElettronica.Validators.ContattiTrasmittenteValidator>
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