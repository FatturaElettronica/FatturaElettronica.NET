using FluentValidation.TestHelper;
using FatturaElettronica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione;

namespace Tests
{
    [TestClass]
    public class ContattiTrasmittenteValidator
    {
        private FatturaElettronica.Validators.ContattiTrasmittenteValidator validator;
        private ContattiTrasmittente challenge;

        [TestInitialize]
        public void Init()
        {
            validator = new FatturaElettronica.Validators.ContattiTrasmittenteValidator();
            challenge = new ContattiTrasmittente();
        }

        [TestMethod]
        public void TelefonoMinMaxLength()
        {
            challenge.Telefono = "";
            validator.ShouldHaveValidationErrorFor(x => x.Telefono, challenge);
            challenge.Telefono = new string('x', 4);
            validator.ShouldHaveValidationErrorFor(x => x.Telefono, challenge);
            challenge.Telefono = new string('x', 13);
            validator.ShouldHaveValidationErrorFor(x => x.Telefono, challenge);
            challenge.Telefono = new string('x', 5);
            validator.ShouldNotHaveValidationErrorFor(x => x.Telefono, challenge);
            challenge.Telefono = new string('x', 12);
            validator.ShouldNotHaveValidationErrorFor(x => x.Telefono, challenge);
        }
        [TestMethod]
        public void EmailMinMaxLength()
        {
            challenge.Email = "";
            validator.ShouldHaveValidationErrorFor(x => x.Email, challenge);
            challenge.Email = new string('x', 6);
            validator.ShouldHaveValidationErrorFor(x => x.Email, challenge);
            challenge.Email = new string('x', 257);
            validator.ShouldHaveValidationErrorFor(x => x.Email, challenge);
            challenge.Email = new string('x', 7);
            validator.ShouldNotHaveValidationErrorFor(x => x.Email, challenge);
            challenge.Email = new string('x', 256);
            validator.ShouldNotHaveValidationErrorFor(x => x.Email, challenge);
        }
    }
}
