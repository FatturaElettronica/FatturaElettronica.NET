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
            Validator.ShouldHaveValidationErrorFor(x => x.Natura, Challenge).WithErrorCode("00401");
            Challenge.DatiIVA.Aliquota = 0m;
            Challenge.DatiIVA.Imposta = 22m;
            Challenge.Natura = "N1";
            Validator.ShouldHaveValidationErrorFor(x => x.Natura, Challenge).WithErrorCode("00401");
            Challenge.DatiIVA.Aliquota = 0m;
            Challenge.DatiIVA.Imposta = 0m;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Natura, Challenge);
        }

        [TestMethod]
        public void NaturaValidateAgainstError00400()
        {
            Challenge.DatiIVA.Aliquota = 0m;
            Challenge.DatiIVA.Imposta = 0m;
            Challenge.Natura = string.Empty;
            Validator.ShouldHaveValidationErrorFor(x => x.Natura, Challenge).WithErrorCode("00400");
            Challenge.DatiIVA.Aliquota = 0m;
            Challenge.DatiIVA.Imposta = 0m;
            Challenge.Natura = null;
            Validator.ShouldHaveValidationErrorFor(x => x.Natura, Challenge).WithErrorCode("00400");
            //challenge.DatiIVA.Aliquota = 22m;
            //challenge.DatiIVA.Imposta = 0m;
            //challenge.Natura = null;
            //validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
            //challenge.DatiIVA.Aliquota = 0m;
            //challenge.DatiIVA.Imposta = 22m;
            //challenge.Natura = string.Empty;
            //validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
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