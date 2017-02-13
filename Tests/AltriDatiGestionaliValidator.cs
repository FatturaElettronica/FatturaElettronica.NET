using FluentValidation.TestHelper;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;

namespace Tests
{
    [TestClass]
    public class AltriDatiGestionaliValidator: BaseClass<AltriDatiGestionali, FatturaElettronica.Validators.AltriDatiGestionaliValidator>
    {
        [TestMethod]
        public void TipoDatoCannotBeEmpty()
        {
            challenge.TipoDato = null;
            validator.ShouldHaveValidationErrorFor(x => x.TipoDato, challenge);
            challenge.TipoDato = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.TipoDato, challenge);
        }
        [TestMethod]
        public void TipoDatoMinMaxLength()
        {
            challenge.TipoDato = new string('x', 11);
            validator.ShouldHaveValidationErrorFor(x => x.TipoDato, challenge);
            challenge.TipoDato = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoDato, challenge);
            challenge.TipoDato = new string('x', 10);
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoDato, challenge);
        }
        [TestMethod]
        public void RiferimentoTestoCanBeEmpty()
        {
            challenge.RiferimentoTesto = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoTesto, challenge);
            challenge.RiferimentoTesto = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoTesto, challenge);
        }
        [TestMethod]
        public void RiferimentoTestoMinMaxLength()
        {
            challenge.RiferimentoTesto = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.RiferimentoTesto, challenge);
            challenge.RiferimentoTesto = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoTesto, challenge);
            challenge.RiferimentoTesto = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoTesto, challenge);
        }
    }
}
