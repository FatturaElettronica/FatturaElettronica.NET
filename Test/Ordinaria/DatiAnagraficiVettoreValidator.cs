namespace Tests
{
    using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
    using FluentValidation.TestHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DatiAnagraficiVettoreValidator : BaseClass<DatiAnagraficiVettore, FatturaElettronica.Validators.DatiAnagraficiVettoreValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA, typeof(FatturaElettronica.Validators.IdFiscaleIVAValidator));
        }
        [TestMethod]
        public void CodiceFiscaleIsOptional()
        {
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
            validator.ShouldHaveChildValidator(x => x.Anagrafica, typeof(FatturaElettronica.Validators.AnagraficaValidator));
        }
        [TestMethod]
        public void NumeroLicenzaIsOptional()
        {
            AssertOptional(x => x.NumeroLicenzaGuida);
        }
        [TestMethod]
        public void NumeroLicenzaGuidaMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroLicenzaGuida, 1, 20);
        }
        [TestMethod]
        public void NumeroLicenzaGuidaMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.NumeroLicenzaGuida);
        }
    }
}
