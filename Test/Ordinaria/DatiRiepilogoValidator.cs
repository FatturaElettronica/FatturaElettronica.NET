using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Test.Ordinaria
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
            Challenge.AliquotaIVA = 22m;
            Challenge.Natura = "N1";
            Validator.ShouldHaveValidationErrorFor(x => x.Natura, Challenge).WithErrorCode("00430");
            Challenge.AliquotaIVA = 0m;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Natura, Challenge);
        }

        [TestMethod]
        public void NaturaValidateAgainstError00400()
        {
            Challenge.AliquotaIVA = 0;
            Challenge.Natura = string.Empty;
            Validator.ShouldHaveValidationErrorFor(x => x.Natura, Challenge).WithErrorCode("00429");
            Challenge.AliquotaIVA = 0;
            Challenge.Natura = null;
            Validator.ShouldHaveValidationErrorFor(x => x.Natura, Challenge).WithErrorCode("00429");
            Challenge.AliquotaIVA = 22m;
            Challenge.Natura = string.Empty;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Natura, Challenge);
        }

        [TestMethod]
        public void NaturaValidateAgainstError00420()
        {
            Challenge.EsigibilitaIVA = "S";
            Challenge.Natura = "N6.1";
            Validator.ShouldHaveValidationErrorFor(x => x.Natura, Challenge).WithErrorCode("00420");

            Challenge.EsigibilitaIVA = "I";
            Validator.ShouldNotHaveValidationErrorFor(x => x.Natura, Challenge);
        }

        [TestMethod]
        public void ImpostaValidateAgainstError00421()
        {
            Challenge.AliquotaIVA = 10;
            Challenge.ImponibileImporto = 70863.00m;
            Challenge.Imposta = 7086.29m;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Imposta, Challenge);
            Challenge.Imposta = 10.01m;
            Validator.ShouldHaveValidationErrorFor(x => x.Imposta, Challenge).WithErrorCode("00421");
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
        public void RiferimentoNormativoIsRequiredWhenNaturaHasValue()
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

        [TestMethod]
        public void SpeseAccessorie()
        {
            AssertDecimalType(x => x.SpeseAccessorie, 2, 13);
        }

        [TestMethod]
        public void ImponibileImporto()
        {
            AssertDecimalType(x => x.ImponibileImporto, 2, 13);
        }

        [TestMethod]
        public void Arrotondamento()
        {
            AssertDecimalType(x => x.Arrotondamento, 8, 19);
        }
    }
}