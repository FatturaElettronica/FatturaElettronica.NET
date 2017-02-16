using System.Linq;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiAnagraficiCessionarioCommittenteValidator 
        : BaseDatiAnagraficiValidator<FatturaElettronica.Common.DatiAnagrafici, FatturaElettronica.Validators.DatiAnagraficiCessionarioCommittenteValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAIsOptional()
        {
            challenge.CodiceFiscale = "x";
            Assert.IsTrue(challenge.IdFiscaleIVA.IsEmpty());

            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "IdFiscaleIVA"));
        }
        [TestMethod]
        public new void CodiceFiscaleIsOptional()
        {
            challenge.IdFiscaleIVA.IdCodice = "x";

            AssertOptional(x => x.CodiceFiscale);
        }
        [TestMethod]
        public void CodiceFiscaleOrIdFiscaleIVAMustHaveValue()
        {
            Assert.IsTrue(string.IsNullOrEmpty(challenge.CodiceFiscale));
            Assert.IsTrue(challenge.IdFiscaleIVA.IsEmpty());

            validator.ShouldHaveValidationErrorFor(x => x.CodiceFiscale, challenge).WithErrorCode("00417");
        }
    }
}
