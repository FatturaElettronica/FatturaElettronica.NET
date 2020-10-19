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
            Validator.ShouldHaveValidationErrorFor(x => x.Imposta, Challenge);
            Validator.ShouldHaveValidationErrorFor(x => x.Aliquota, Challenge);

            Challenge.Aliquota = null;
            Challenge.Imposta = 0m;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Imposta, Challenge);
            Validator.ShouldNotHaveValidationErrorFor(x => x.Aliquota, Challenge);

            Challenge.Aliquota = 0m;
            Challenge.Imposta = null;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Imposta, Challenge);
            Validator.ShouldNotHaveValidationErrorFor(x => x.Aliquota, Challenge);
        }
    }
}