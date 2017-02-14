using FluentValidation.TestHelper;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.FatturaElettronicaBody.DatiVeicoli;
using System;

namespace Tests
{
    [TestClass]
    public class DatiVeicoliValidator: BaseClass<DatiVeicoli, FatturaElettronica.Validators.DatiVeicoliValidator>
    {
        [TestMethod]
        public void TotalePercorsoCannotBeEmpty()
        {
            validator.ShouldHaveValidationErrorFor(x => x.TotalePercorso, challenge);
            challenge.TotalePercorso = "x";
            validator.ShouldNotHaveValidationErrorFor(x => x.TotalePercorso, challenge);
        }
        [TestMethod]
        public void TotalePercorsoMinMaxLength()
        {
            challenge.TotalePercorso = new string('x', 16);
            validator.ShouldHaveValidationErrorFor(x => x.TotalePercorso, challenge);
            challenge.TotalePercorso = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.TotalePercorso, challenge);
            challenge.TotalePercorso = new string('x', 15);
            validator.ShouldNotHaveValidationErrorFor(x => x.TotalePercorso, challenge);
        }
        [TestMethod]
        public void DataCannotBeEmpty()
        {
            validator.ShouldHaveValidationErrorFor(x => x.Data, challenge);
            challenge.Data = DateTime.MinValue;
            validator.ShouldNotHaveValidationErrorFor(x => x.Data, challenge);
        }
    }
}
