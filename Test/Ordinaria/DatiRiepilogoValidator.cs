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
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Natura).WithErrorCode("00430");
            
            Challenge.AliquotaIVA = 0m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Natura);
        }

        [TestMethod]
        public void NaturaValidateAgainstError00400()
        {
            Challenge.AliquotaIVA = 0;
            Challenge.Natura = string.Empty;
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Natura).WithErrorCode("00429");
            
            Challenge.AliquotaIVA = 0;
            Challenge.Natura = null;
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Natura).WithErrorCode("00429");
            
            Challenge.AliquotaIVA = 22m;
            Challenge.Natura = string.Empty;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Natura);
        }

        [TestMethod]
        public void NaturaValidateAgainstError00420()
        {
            Challenge.EsigibilitaIVA = "S";
            Challenge.Natura = "N6.1";
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Natura).WithErrorCode("00420");

            Challenge.EsigibilitaIVA = "I";
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Natura);
        }

        [TestMethod]
        public void ImpostaValidateAgainstError00421()
        {
            Challenge.AliquotaIVA = 10;
            Challenge.ImponibileImporto = 70863.00m;
            Challenge.Imposta = 7086.29m;
            var result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Imposta);
            
            Challenge.Imposta = 10.01m;
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Imposta).WithErrorCode("00421");
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