using System.Linq;
using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class IdentificativiFiscaliValidator : BaseClass<IdentificativiFiscali,
        FatturaElettronica.Validators.Semplificata.IdentificativiFiscaliValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(x => x.IdFiscaleIVA,
                typeof(Validators.IdFiscaleIVAValidator));
        }

        [TestMethod]
        public void CodiceFiscaleIsOptional()
        {
            Challenge.IdFiscaleIVA.IdCodice = "x";
            AssertOptional(x => x.CodiceFiscale);
        }

        [TestMethod]
        public void CodiceFiscaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceFiscale, 11, 16);
        }

        [TestMethod]
        public void IdFiscaleIVAIsOptional()
        {
            Challenge.CodiceFiscale = "x";
            Assert.IsTrue(Challenge.IdFiscaleIVA.IsEmpty());

            var r = Validator.Validate(Challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "IdFiscaleIVA"));
        }

        [TestMethod]
        public void CodiceFiscaleOrIdFiscaleIVAMustHaveValue()
        {
            Assert.IsTrue(string.IsNullOrEmpty(Challenge.CodiceFiscale));
            Assert.IsTrue(Challenge.IdFiscaleIVA.IsEmpty());

            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.CodiceFiscale).WithErrorCode("00417");
        }
    }
}