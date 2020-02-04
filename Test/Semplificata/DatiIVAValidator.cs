using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Semplificata.Tests
{
    [TestClass]
    public class DatiIVAValidator : BaseClass<DatiIVA, FatturaElettronica.Validators.Semplificata.DatiIVAValidator>
    {
        [TestMethod]
        public void AliquotaOImportoRequired()
        {
            challenge.Imposta = null;
            challenge.Aliquota = null;
            validator.ShouldHaveValidationErrorFor(x => x.Imposta, challenge);
            validator.ShouldHaveValidationErrorFor(x => x.Aliquota, challenge);

            challenge.Aliquota = null;
            challenge.Imposta = 0m;
            validator.ShouldNotHaveValidationErrorFor(x => x.Imposta, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Aliquota, challenge);

            challenge.Aliquota = 0m;
            challenge.Imposta = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Imposta, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Aliquota, challenge);
        }
    }
}
