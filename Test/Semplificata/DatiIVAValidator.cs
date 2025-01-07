using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class DatiIVAValidator : BaseClass<DatiIVA, FatturaElettronica.Validators.Semplificata.DatiIVAValidator>
    {
        [TestMethod]
        public void AliquotaOImportoRequired()
        {
            Challenge.Imposta = null;
            Challenge.Aliquota = null;
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Imposta);
            result.ShouldHaveValidationErrorFor(x => x.Aliquota);

            Challenge.Aliquota = null;
            Challenge.Imposta = 0m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Imposta);
            result.ShouldNotHaveValidationErrorFor(x => x.Aliquota);

            Challenge.Aliquota = 0m;
            Challenge.Imposta = null;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Imposta);
            result.ShouldNotHaveValidationErrorFor(x => x.Aliquota);
        }

        [TestMethod]
        public void AliquotaShouldBeLessOrEqualTo100()
        {
            Challenge.Imposta = null;
            Challenge.Aliquota = 101;
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Aliquota);

            Challenge.Imposta = null;
            Challenge.Aliquota = 100;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Aliquota);
        }
    }
}