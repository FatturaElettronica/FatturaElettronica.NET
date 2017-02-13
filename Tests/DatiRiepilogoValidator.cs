using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;
using System.Linq;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiRiepilogoValidator: BaseClass<DatiRiepilogo, FatturaElettronica.Validators.DatiRiepilogoValidator>
    {
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
        public void NaturaValidateAgainstError00430()
        {
            challenge.AliquotaIVA = 22m;
            challenge.Natura = "N1";
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00430");
            challenge.AliquotaIVA = 0m;
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
        }
        [TestMethod]
        public void NaturaValidateAgainstError00400()
        {
            challenge.AliquotaIVA = 0;
            challenge.Natura = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00429");
            challenge.AliquotaIVA = 0;
            challenge.Natura = null;
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00429");
            challenge.AliquotaIVA = 22m;
            challenge.Natura = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
        }
        [TestMethod]
        public void NaturaValidateAgainstError00420()
        {
            challenge.EsigibilitaIVA = "S";
            challenge.Natura = "N6";
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00420");

            challenge.EsigibilitaIVA = "I";
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
        }
        [TestMethod]
        public void ImpostaValidateAgainstError00421()
        {
            challenge.AliquotaIVA = 22m;
            challenge.ImponibileImporto = 100m;
            challenge.Imposta = 22m;
            validator.ShouldNotHaveValidationErrorFor(x => x.Imposta, challenge);
            challenge.Imposta = 22.01m;
            validator.ShouldHaveValidationErrorFor(x => x.Imposta, challenge).WithErrorCode("00421");
        }
        [TestMethod]
        public void EsigibilitaIVACanBeEmpty()
        {
            challenge.EsigibilitaIVA = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.EsigibilitaIVA, challenge);
            challenge.EsigibilitaIVA = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.EsigibilitaIVA, challenge);
        }
        [TestMethod]
        public void EsigibilitaIVACanOnlyAcceptDomainValues()
        {
            challenge.EsigibilitaIVA = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.EsigibilitaIVA, challenge);
            challenge.EsigibilitaIVA = "I";
            validator.ShouldNotHaveValidationErrorFor(x => x.EsigibilitaIVA, challenge);
            challenge.EsigibilitaIVA = "D";
            validator.ShouldNotHaveValidationErrorFor(x => x.EsigibilitaIVA, challenge);
            challenge.EsigibilitaIVA = "S";
            validator.ShouldNotHaveValidationErrorFor(x => x.EsigibilitaIVA, challenge);
        }
        [TestMethod]
        public void RiferimentoNormativoCanBeEmpty()
        {
            challenge.RiferimentoNormativo = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoNormativo, challenge);
            challenge.RiferimentoNormativo = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoNormativo, challenge);
        }
        [TestMethod]
        public void RiferimentoNormativoMinMaxLength()
        {
            challenge.RiferimentoNormativo = new string('x', 101);
            validator.ShouldHaveValidationErrorFor(x => x.RiferimentoNormativo, challenge);
            challenge.RiferimentoNormativo = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoNormativo, challenge);
            challenge.RiferimentoNormativo = new string('x', 100);
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoNormativo, challenge);
        }
    }
}
