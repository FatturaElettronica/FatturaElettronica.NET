using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Tabelle;

namespace Tests
{
    [TestClass]
    public class DettaglioLineeValidator: BaseClass<DettaglioLinee, FatturaElettronica.Validators.DettaglioLineeValidator>
    {
        [TestMethod]
        public void TipoCessionePrestazioneIsOptional()
        {
            AssertOptional(x => x.TipoCessionePrestazione);
        }
        [TestMethod]
        public void TipoCessionePrestazioneOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<TipoCessionePrestazione>(x => x.TipoCessionePrestazione);
        }
        [TestMethod]
        public void CodiceArticoloHasCollectionValidator()
        {
            validator.ShouldHaveChildValidator(x => x.CodiceArticolo, typeof(FatturaElettronica.Validators.CodiceArticoloValidator));
        }
        [TestMethod]
        public void CodiceArticoloCollectionCanBeEmpty()
        {
            AssertCollectionCanBeEmpty(x => x.CodiceArticolo);
        }
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
        public void UnitaMisuraIsOptional()
        {
            AssertOptional(x => x.UnitaMisura);
        }
        [TestMethod]
        public void UnitaMisuraMinMaxLength()
        {
            AssertMinMaxLength(x => x.UnitaMisura, 1, 10);
        }
        [TestMethod]
        public void UnitaMisuraMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.UnitaMisura);
        }
        [TestMethod]
        public void ScontoMaggioazioneHasChildValidator() 
        {
            validator.ShouldHaveChildValidator(x => x.ScontoMaggiorazione, typeof(FatturaElettronica.Validators.ScontoMaggiorazioneValidator));
        }
        [TestMethod]
        public void ScontoMaggiorazioneCollectionCanBeEmpty()
        {
            AssertCollectionCanBeEmpty(x => x.ScontoMaggiorazione);
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

            // https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/45
            challenge.ScontoMaggiorazione.Clear();
            challenge.PrezzoUnitario = 0.865951m;
            challenge.Quantita = 98;
            challenge.PrezzoTotale = 84.863198m;
            validator.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale, challenge);
        }

        [TestMethod]
        public void RitenutaIsOptional()
        {
            AssertOptional(x => x.Ritenuta);
        }
        [TestMethod]
        public void RitenutaOnlyAccepstSIValue()
        {
            AssertOnlyAcceptsSIValue(x => x.Ritenuta);
        }
        [TestMethod]
        public void NaturaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<Natura>(x => x.Natura);
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
        public void RiferimentoAmministrazioneIsOptional()
        {
            AssertOptional(x => x.RiferimentoAmministrazione);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneMinMaxLength()
        {
            AssertMinMaxLength(x => x.RiferimentoAmministrazione, 1, 20);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.RiferimentoAmministrazione);
        }
        [TestMethod]
        public void AltriDatiGestionaliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.AltriDatiGestionali, typeof(FatturaElettronica.Validators.AltriDatiGestionaliValidator));
        }
        [TestMethod]
        public void AltriDatiGestionaliCollectionCanBeEmpty()
        {
            AssertCollectionCanBeEmpty(x => x.AltriDatiGestionali);
        }
    }
}