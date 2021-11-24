using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class DatiBeniServiziValidator : BaseClass<DatiBeniServizi,
        FatturaElettronica.Validators.Semplificata.DatiBeniServiziValidator>
    {
        [TestMethod]
        public void DescrizioneIsRequired()
        {
            AssertRequired(x => x.Descrizione);
        }

        [TestMethod]
        public void DescrizioneMinMaxLength()
        {
            AssertMinMaxLength(x => x.Descrizione, 1, 1000);
        }

        [TestMethod]
        public void DescrizioneMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.Descrizione);
        }

        [TestMethod]
        public void ImportoIsRequired()
        {
            AssertRequired(x => x.Importo);
        }

        [TestMethod]
        public void DatiIVAHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiIVA,
                typeof(FatturaElettronica.Validators.Semplificata.DatiIVAValidator));
        }

        [TestMethod]
        public void NaturaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<NaturaSemplificata>(x => x.Natura);
        }

        [TestMethod]
        public void NaturaValidateAgainstError00401()
        {
            Challenge.DatiIVA.Aliquota = 22m;
            Challenge.DatiIVA.Imposta = 0m;
            Challenge.Natura = "N1";
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Natura).WithErrorCode("00401");

            Challenge.DatiIVA.Aliquota = 0m;
            Challenge.DatiIVA.Imposta = 22m;
            Challenge.Natura = "N1";
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Natura).WithErrorCode("00401");

            Challenge.DatiIVA.Aliquota = 0m;
            Challenge.DatiIVA.Imposta = 0m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Natura);
        }

        [TestMethod]
        public void NaturaValidateAgainstError00400()
        {
            Challenge.DatiIVA.Aliquota = 0m;
            Challenge.DatiIVA.Imposta = 0m;
            Challenge.Natura = string.Empty;
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Natura).WithErrorCode("00400");

            Challenge.DatiIVA.Aliquota = 0m;
            Challenge.DatiIVA.Imposta = 0m;
            Challenge.Natura = null;
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Natura).WithErrorCode("00400");
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
        public void RiferimentoNormativoMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.RiferimentoNormativo);
        }
    }
}