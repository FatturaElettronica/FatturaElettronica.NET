using FatturaElettronica.Common;
using FatturaElettronica.Validators;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class IdFiscaleValidator
    {

        private IdFiscaleIVAValidator validator;
        private IdFiscaleIVA challenge;

        [TestInitialize]
        public void Init()
        {
            validator = new IdFiscaleIVAValidator();
            challenge = new IdFiscaleIVA();
        }

        [TestMethod]
        public void IdPaeseCannotBeEmpty()
        {
            challenge.IdPaese = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.IdPaese, challenge);
        }
        [TestMethod]
        public void IdPaeseCanOnlyAcceptDomainValues()
        {
            challenge.IdPaese = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.IdPaese, challenge);
            challenge.IdPaese = "XX";
            validator.ShouldHaveValidationErrorFor(x => x.IdPaese, challenge);
            challenge.IdPaese = "IT";
            validator.ShouldNotHaveValidationErrorFor(x => x.IdPaese, challenge);
        }
        [TestMethod]
        public void IdCodiceCannotBeEmpty()
        {
            challenge.IdCodice = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.IdCodice, challenge);
        }

        [TestMethod]
        public void IdCodiceMinMaxLength()
        {
            challenge.IdCodice = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.IdCodice, challenge);
            challenge.IdCodice = new string('x', 29);
            validator.ShouldHaveValidationErrorFor(x => x.IdCodice, challenge);
            challenge.IdCodice = "1";
            validator.ShouldNotHaveValidationErrorFor(x => x.IdCodice, challenge);
        }
    }
}
