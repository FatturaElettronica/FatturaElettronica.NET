using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DatiDDTValidator: BaseClass<DatiDDT, FatturaElettronica.Validators.DatiDDTValidator>
    {
        [TestMethod]
        public void NumeroDDTCannotBeEmpty()
        {
            challenge.NumeroDDT = null;
            validator.ShouldHaveValidationErrorFor(x => x.NumeroDDT, challenge);
            challenge.NumeroDDT = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.NumeroDDT, challenge);
        }
        [TestMethod]
        public void NumeroDDTMinMaxLength()
        {
            challenge.NumeroDDT = new string('x', 21);
            validator.ShouldHaveValidationErrorFor(x => x.NumeroDDT, challenge);
            challenge.NumeroDDT = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroDDT, challenge);
            challenge.NumeroDDT = new string('x', 20);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroDDT, challenge);
        }
    }
}
