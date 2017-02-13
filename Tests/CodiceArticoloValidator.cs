using FluentValidation.TestHelper;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;

namespace Tests
{
    [TestClass]
    public class CodiceArticoloValidator: BaseClass<CodiceArticolo, FatturaElettronica.Validators.CodiceArticoloValidator>
    {
        [TestMethod]
        public void CodiceTipoCannotBeEmpty()
        {
            validator.ShouldHaveValidationErrorFor(x => x.CodiceTipo, challenge);
            challenge.CodiceTipo = "x";
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceTipo, challenge);
        }
        [TestMethod]
        public void CodiceTipoMinMaxLength()
        {
            challenge.CodiceTipo = new string('x', 36);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceTipo, challenge);
            challenge.CodiceTipo = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceTipo, challenge);
            challenge.CodiceTipo = new string('x', 35);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceTipo, challenge);
        }
        [TestMethod]
        public void CodiceArticoloCannotBeEmpty()
        {
            validator.ShouldHaveValidationErrorFor(x => x.CodiceValore, challenge);
            challenge.CodiceValore = "x";
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceValore, challenge);
        }
        [TestMethod]
        public void CodiceValoreMinMaxLength()
        {
            challenge.CodiceValore = new string('x', 36);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceValore, challenge);
            challenge.CodiceValore = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceValore, challenge);
            challenge.CodiceValore = new string('x', 35);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceValore, challenge);
        }
    }
}
