using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Semplificata.Tests
{
    [TestClass]
    public class DatiBeniServiziValidator : BaseClass<DatiBeniServizi, FatturaElettronica.Validators.Semplificata.DatiBeniServiziValidator>
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
        public void NaturaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<NaturaSemplificata>(x => x.Natura);
        }
        [TestMethod]
        public void NaturaValidateAgainstError00401()
        {
            challenge.DatiIVA.Aliquota = 22m;
            challenge.DatiIVA.Imposta = 0m;
            challenge.Natura = "N1";
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00401");
            challenge.DatiIVA.Aliquota = 0m;
            challenge.DatiIVA.Imposta = 22m;
            challenge.Natura = "N1";
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00401");
            challenge.DatiIVA.Aliquota = 0m;
            challenge.DatiIVA.Imposta = 0m;
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
        }
        [TestMethod]
        public void NaturaValidateAgainstError00400()
        {
            challenge.DatiIVA.Aliquota = 0m;
            challenge.DatiIVA.Imposta = 0m;
            challenge.Natura = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00400");
            challenge.DatiIVA.Aliquota = 0m;
            challenge.DatiIVA.Imposta = 0m;
            challenge.Natura = null;
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00400");
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