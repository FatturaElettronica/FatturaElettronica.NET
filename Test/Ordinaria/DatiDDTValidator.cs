using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FluentValidation.TestHelper;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiDDTValidator
        : BaseClass<DatiDDT, FatturaElettronica.Validators.DatiDDTValidator>
    {
        [TestMethod]
        public void NumeroDDTIsRequired()
        {
            AssertRequired(x => x.NumeroDDT);
        }

        [TestMethod]
        public void NumeroDDTMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroDDT, 1, 20);
        }

        [TestMethod]
        public void NumeroDDTMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.NumeroDDT);
        }

        [TestMethod]
        public void RiferimentoNumeroLineaValidatorMinMax()
        {
            Challenge.RiferimentoNumeroLinea = new() { -1 };
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.RiferimentoNumeroLinea);

            Challenge.RiferimentoNumeroLinea = new() { 10000 };
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.RiferimentoNumeroLinea);

            Challenge.RiferimentoNumeroLinea = new() { 1 };
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.RiferimentoNumeroLinea);

            Challenge.RiferimentoNumeroLinea = new() { 9999 };
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.RiferimentoNumeroLinea);
        }
    }
}