using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ContattiValidator : BaseTestClass<Contatti, FatturaElettronica.Validators.ContattiValidator>
    {
        [TestMethod]
        public void TelefonoMinMaxLength()
        {
            challenge.Telefono = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Telefono, challenge);
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
        public void FaxMinMaxLength()
        {
            challenge.Fax = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Fax, challenge);
            challenge.Fax = new string('x', 4);
            validator.ShouldHaveValidationErrorFor(x => x.Fax, challenge);
            challenge.Fax = new string('x', 13);
            validator.ShouldHaveValidationErrorFor(x => x.Fax, challenge);
            challenge.Fax = new string('x', 5);
            validator.ShouldNotHaveValidationErrorFor(x => x.Fax, challenge);
            challenge.Fax = new string('x', 12);
            validator.ShouldNotHaveValidationErrorFor(x => x.Fax, challenge);
        }
        [TestMethod]
        public void EmailMinMaxLength()
        {
            challenge.Email = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Email, challenge);
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
