using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiAnagraficiVettoreValidator : BaseClass<DatiAnagraficiVettore,
        FatturaElettronica.Validators.DatiAnagraficiVettoreValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA, typeof(Validators.IdFiscaleIVAValidator));
        }

        [TestMethod]
        public void CodiceFiscaleIsOptional()
        {
            AssertOptional(x => x.CodiceFiscale);
        }

        [TestMethod]
        public void CodiceFiscaleMustBeDigitsOrUpperCase()
        {
            AssertDigitsOrUppercase(x => x.CodiceFiscale);
        }

        [TestMethod]
        public void CodiceFiscaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceFiscale, 11, 16, 'X', "RegularExpressionValidator");
        }

        [TestMethod]
        public void AnagraficaHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.Anagrafica, typeof(Validators.AnagraficaValidator));
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