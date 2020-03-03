using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.DatiTrasmissione;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Ordinaria.Tests
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
            challenge.Email = "not really";
            validator.ShouldHaveValidationErrorFor(x=>x.Email,challenge);
            challenge.Email = "not@really";
            validator.ShouldHaveValidationErrorFor(x=>x.Email,challenge);
            challenge.Email = "maybe@we.can";
            validator.ShouldNotHaveValidationErrorFor(x=>x.Email,challenge);
        }
    }
}
