namespace Tests
{
    using System.Linq;
    using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CessionarioCommittente;
    using FluentValidation.TestHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DatiAnagraficiCessionarioCommittenteValidator
        : BaseClass<DatiAnagraficiCessionarioCommittente,
            FatturaElettronica.Validators.DatiAnagraficiCessionarioCommittenteValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(x => x.IdFiscaleIVA,
                typeof(FatturaElettronica.Validators.IdFiscaleIVAValidator));
        }
        [TestMethod]
        public void CodiceFiscaleIsOptional()
        {
            challenge.IdFiscaleIVA.IdCodice = "x";
            AssertOptional(x => x.CodiceFiscale);
        }
        [TestMethod]
        public void CodiceFiscaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceFiscale, 11, 16);
        }
        [TestMethod]
        public void AnagraficaHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Anagrafica,
                typeof(FatturaElettronica.Validators.AnagraficaValidator));
        }
        [TestMethod]
        public void IdFiscaleIVAIsOptional()
        {
            challenge.CodiceFiscale = "x";
            Assert.IsTrue(challenge.IdFiscaleIVA.IsEmpty());

            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "IdFiscaleIVA"));
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
