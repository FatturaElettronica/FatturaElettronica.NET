using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.DatiTrasmissione;
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
            Validator.ShouldHaveValidationErrorFor(x => x.Email, Challenge);
            Challenge.Email = "not@really";
            Validator.ShouldHaveValidationErrorFor(x => x.Email, Challenge);
            Challenge.Email = "maybe@we.can";
            Validator.ShouldNotHaveValidationErrorFor(x => x.Email, Challenge);
        }
    }
}