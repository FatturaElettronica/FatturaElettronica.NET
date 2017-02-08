using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiOrdineAcquistoValidator: BaseClass<DatiOrdineAcquisto, FatturaElettronica.Validators.DatiOrdineAcquistoValidator>
    {
        [TestMethod]
        public void IdDocumentoCannotBeEmpty()
        {
            challenge.IdDocumento = null;
            validator.ShouldHaveValidationErrorFor(x => x.IdDocumento, challenge);
            challenge.IdDocumento = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.IdDocumento, challenge);
        }
        [TestMethod]
        public void IdDocumentoMinMaxLength()
        {
            challenge.IdDocumento = new string('x', 21);
            validator.ShouldHaveValidationErrorFor(x => x.IdDocumento, challenge);
            challenge.IdDocumento = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.IdDocumento, challenge);
            challenge.IdDocumento = new string('x', 20);
            validator.ShouldNotHaveValidationErrorFor(x => x.IdDocumento, challenge);
        }
        [TestMethod]
        public void NumItemCanBeEmpty()
        {
            challenge.NumItem = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.NumItem, challenge);
            challenge.NumItem = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.NumItem, challenge);
        }
        [TestMethod]
        public void NumItemMinMaxLength()
        {
            challenge.NumItem = new string('x', 21);
            validator.ShouldHaveValidationErrorFor(x => x.NumItem, challenge);
            challenge.NumItem = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumItem, challenge);
            challenge.NumItem = new string('x', 20);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumItem, challenge);
        }
        [TestMethod]
        public void CodiceCommessaCanBeEmpty()
        {
            challenge.CodiceCommessaConvenzione = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCommessaConvenzione, challenge);
            challenge.CodiceCommessaConvenzione = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCommessaConvenzione, challenge);
        }
        [TestMethod]
        public void CodiceCommessaMinMaxLength()
        {
            challenge.CodiceCommessaConvenzione = new string('x', 101);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceCommessaConvenzione, challenge);
            challenge.CodiceCommessaConvenzione = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCommessaConvenzione, challenge);
            challenge.CodiceCommessaConvenzione = new string('x', 100);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCommessaConvenzione, challenge);
        }
        [TestMethod]
        public void CodiceCUPCanBeEmpty()
        {
            challenge.CodiceCUP = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCUP, challenge);
            challenge.CodiceCUP = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCUP, challenge);
        }
        [TestMethod]
        public void CodiceCUPMinMaxLength()
        {
            challenge.CodiceCUP = new string('x', 16);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceCUP, challenge);
            challenge.CodiceCUP = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCUP, challenge);
            challenge.CodiceCUP = new string('x', 15);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCUP, challenge);
        }
        [TestMethod]
        public void CodiceCIGCanBeEmpty()
        {
            challenge.CodiceCIG = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCIG, challenge);
            challenge.CodiceCIG = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCIG, challenge);
        }
        [TestMethod]
        public void CodiceCIGMinMaxLength()
        {
            challenge.CodiceCIG = new string('x', 16);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceCIG, challenge);
            challenge.CodiceCIG = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCIG, challenge);
            challenge.CodiceCIG = new string('x', 15);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceCIG, challenge);
        }
    }
}
