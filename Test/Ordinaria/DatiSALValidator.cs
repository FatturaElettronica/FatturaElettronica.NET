using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiSALValidator
        : BaseClass<DatiSAL, FatturaElettronica.Validators.DatiSALValidator>
    {
        [TestMethod]
        public void RiferimentoFaseValidatorMinMax()
        {
            Challenge.RiferimentoFase = 0;
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.RiferimentoFase);

            Challenge.RiferimentoFase = 1000;
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.RiferimentoFase);

            Challenge.RiferimentoFase = 1;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.RiferimentoFase);

            Challenge.RiferimentoFase = 999;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.RiferimentoFase);
        }
    }
}