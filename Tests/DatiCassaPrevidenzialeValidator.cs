using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiCassaPrevidenzialeValidator: BaseClass<DatiCassaPrevidenziale, FatturaElettronica.Validators.DatiCassaPrevidenzialeValidator>
    {
        [TestMethod]
        public void TipoCassaCannotBeEmpty()
        {
            challenge.TipoCassa = null;
            validator.ShouldHaveValidationErrorFor(x => x.TipoCassa, challenge);
            challenge.TipoCassa = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.TipoCassa, challenge);
        }
        [TestMethod]
        public void TipoCassaCanOnlyAcceptDomainValues()
        {
            challenge.TipoCassa = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.TipoCassa, challenge);
            challenge.TipoCassa = "TC01";
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoCassa, challenge);
            challenge.TipoCassa = "TC22";
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoCassa, challenge);
        }
        [TestMethod]
        public void NaturaCannotBeEmpty()
        {
            challenge.Natura = null;
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge);
            challenge.Natura = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge);
        }
        [TestMethod]
        public void NaturaCanOnlyAcceptDomainValues()
        {
            challenge.Natura = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge);
            challenge.Natura = "N1";
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
            challenge.Natura = "N7";
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneMinMaxLength()
        {
            challenge.RiferimentoAmministrazione = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoAmministrazione, challenge);
            challenge.RiferimentoAmministrazione = new string('x', 21);
            validator.ShouldHaveValidationErrorFor(x => x.RiferimentoAmministrazione, challenge);
            challenge.RiferimentoAmministrazione = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoAmministrazione, challenge);
            challenge.RiferimentoAmministrazione = new string('x', 20);
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoAmministrazione, challenge);
        }
        [TestMethod]
        public void RitenutaCanBeEmpty()
        {
            challenge.Ritenuta = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Ritenuta, challenge);
            challenge.Ritenuta = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.Ritenuta, challenge);
        }
        [TestMethod]
        public void RitenutaCanOnlyAcceptSIValue()
        {
            challenge.Ritenuta = "NO";
            validator.ShouldHaveValidationErrorFor(x => x.Ritenuta, challenge);
            challenge.Ritenuta = "SI";
            validator.ShouldNotHaveValidationErrorFor(x => x.Ritenuta, challenge);
        }
    }
}
