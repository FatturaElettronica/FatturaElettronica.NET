using FluentValidation.TestHelper;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;

namespace Tests
{
    [TestClass]
    public class DettaglioLineeValidator: BaseClass<DettaglioLinee, FatturaElettronica.Validators.DettaglioLineeValidator>
    {
        [TestMethod]
        public void TipoCessionePrestazioneCanBeEmpty()
        {
            challenge.TipoCessionePrestazione = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoCessionePrestazione, challenge);
            challenge.TipoCessionePrestazione = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoCessionePrestazione, challenge);
        }
        [TestMethod]
        public void TipoCessionePrestazioneCanOnlyAcceptDomainValues()
        {
            challenge.TipoCessionePrestazione = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.TipoCessionePrestazione, challenge);
            challenge.TipoCessionePrestazione = "SC";
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoCessionePrestazione, challenge);
            challenge.TipoCessionePrestazione = "AB";
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoCessionePrestazione, challenge);
        }
        [TestMethod]
        public void CodiceArticoloHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.CodiceArticolo, typeof(FatturaElettronica.Validators.CodiceArticoloValidator));
        }
        [TestMethod]
        public void CodiceArticoloCollectionCanBeEmpty()
        {
            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "CodiceArticolo"));
        }
        [TestMethod]
        public void DescrizioneCannotBeEmpty()
        {
            challenge.Descrizione = null;
            validator.ShouldHaveValidationErrorFor(x => x.Descrizione, challenge);
            challenge.Descrizione = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Descrizione, challenge);
        }
        [TestMethod]
        public void DescrizioneMinMaxLength()
        {
            challenge.Descrizione = new string('x', 1001);
            validator.ShouldHaveValidationErrorFor(x => x.Descrizione, challenge);
            challenge.Descrizione = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.Descrizione, challenge);
            challenge.Descrizione = new string('x', 1000);
            validator.ShouldNotHaveValidationErrorFor(x => x.Descrizione, challenge);
        }
        [TestMethod]
        public void UnitaMisuraCanBeEmpty()
        {
            challenge.UnitaMisura = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.UnitaMisura, challenge);
            challenge.UnitaMisura = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.UnitaMisura, challenge);
        }
        [TestMethod]
        public void UnitaMisuraMinMaxLength()
        {
            challenge.UnitaMisura = new string('x', 11);
            validator.ShouldHaveValidationErrorFor(x => x.UnitaMisura, challenge);
            challenge.UnitaMisura = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.UnitaMisura, challenge);
            challenge.UnitaMisura = new string('x', 10);
            validator.ShouldNotHaveValidationErrorFor(x => x.UnitaMisura, challenge);
        }
        [TestMethod]
        public void ScontoMaggioazioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.ScontoMaggiorazione, typeof(FatturaElettronica.Validators.ScontoMaggiorazioneValidator));
        }
        [TestMethod]
        public void ScontoMaggiorazioneCollectionCanBeEmpty()
        {
            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "ScontoMaggiorazione"));
        }
        [TestMethod]
        public void PrezzoTotaleValidatesAgainstError00423()
        {

            challenge.PrezzoUnitario = 13.4426m;
            challenge.Quantita = 2;
            challenge.PrezzoTotale = 26.89m;
            validator.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale, challenge);

            challenge.PrezzoUnitario = 3.0246m;
            challenge.Quantita = 5;
            challenge.PrezzoTotale = 15.12m;
            validator.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale, challenge);

            challenge.PrezzoUnitario = 5.7377m;
            challenge.Quantita = 0.2m;
            challenge.PrezzoTotale = 1.15m;
            validator.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale, challenge);

            challenge.PrezzoUnitario = 0.0492m;
            challenge.Quantita = 4;
            challenge.PrezzoTotale = 0.20m;
            validator.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale, challenge);

            challenge.PrezzoUnitario = 22;
            challenge.Quantita = 4;
            challenge.PrezzoTotale = 88;
            validator.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale, challenge);

            challenge.PrezzoUnitario = 9.2425m;
            challenge.Quantita = 4;
            challenge.PrezzoTotale = 36.97m;
            validator.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale, challenge);

            challenge.PrezzoUnitario = 12.235m;
            challenge.Quantita = 1;
            challenge.PrezzoTotale = 12.24m;
            validator.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale, challenge);

            challenge.PrezzoUnitario = 19.30m;
            challenge.Quantita = 1;
            challenge.ScontoMaggiorazione.Add(new FatturaElettronica.Common.ScontoMaggiorazione { Tipo = "SC", Percentuale = 15m });
            challenge.PrezzoTotale = 16.41m;
            validator.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale, challenge);

            challenge.PrezzoUnitario = 20.5m;
            challenge.Quantita = 2;
            challenge.PrezzoTotale = 42;
            validator.ShouldHaveValidationErrorFor(x => x.PrezzoTotale, challenge).WithErrorCode("00423");
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
        public void NaturaValidateAgainstError00401()
        {
            challenge.AliquotaIVA = 22m;
            challenge.Natura = "N1";
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00401");
            challenge.AliquotaIVA = 0m;
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
        }
        [TestMethod]
        public void NaturaValidateAgainstError00400()
        {
            challenge.AliquotaIVA = 0;
            challenge.Natura = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00400");
            challenge.AliquotaIVA = 0;
            challenge.Natura = null;
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00400");
            challenge.AliquotaIVA = 22m;
            challenge.Natura = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneCanBeEmpty()
        {
            challenge.RiferimentoAmministrazione = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoAmministrazione, challenge);
            challenge.RiferimentoAmministrazione = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoAmministrazione, challenge);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneMinMaxLength()
        {
            challenge.RiferimentoAmministrazione = new string('x', 21);
            validator.ShouldHaveValidationErrorFor(x => x.RiferimentoAmministrazione, challenge);
            challenge.RiferimentoAmministrazione = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoAmministrazione, challenge);
            challenge.RiferimentoAmministrazione = new string('x', 20);
            validator.ShouldNotHaveValidationErrorFor(x => x.RiferimentoAmministrazione, challenge);
        }
        [TestMethod]
        public void AltriDatiGestionaliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.AltriDatiGestionali, typeof(FatturaElettronica.Validators.AltriDatiGestionaliValidator));
        }
        [TestMethod]
        public void AltriDatiGestionaliCollectionCanBeEmpty()
        {
            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "AltriDatiGestionali"));
        }
    }
}
