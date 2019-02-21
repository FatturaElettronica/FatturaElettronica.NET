using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Tabelle;

namespace Tests
{
    [TestClass]
    public class DatiRiepilogoValidator
        : BaseClass<DatiRiepilogo, FatturaElettronica.Validators.DatiRiepilogoValidator>
    {
        [TestMethod]
        public void NaturaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<Natura>(x => x.Natura);
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
            challenge.AliquotaIVA = 10;
            challenge.ImponibileImporto = 70863.00m;
            challenge.Imposta = 7086.29m;
            validator.ShouldNotHaveValidationErrorFor(x => x.Imposta, challenge);
            challenge.Imposta = 10.01m;
            validator.ShouldHaveValidationErrorFor(x => x.Imposta, challenge).WithErrorCode("00421");
        }
        [TestMethod]
        public void EsigibilitaIVAIsOptional()
        {
            AssertOptional(x => x.EsigibilitaIVA);
        }
        [TestMethod]
        public void EsigibilitaIVAOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<EsigibilitaIVA>(x => x.EsigibilitaIVA);
        }
        [TestMethod]
        public void RiferimentoNormativoIsOptional()
        {
            AssertOptional(x => x.RiferimentoNormativo);
        }
        [TestMethod]
        public void RiferimentoNormativoMinMaxLength()
        {
            AssertMinMaxLength(x => x.RiferimentoNormativo, 1, 100);
        }
        [TestMethod]
        public void RiferimentoNormativoMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.RiferimentoNormativo);
        }
    }
}
