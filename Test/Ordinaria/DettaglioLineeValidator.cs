using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class
        DettaglioLineeValidator : BaseClass<DettaglioLinee, FatturaElettronica.Validators.DettaglioLineeValidator>
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
            Validator.ShouldHaveChildValidator(x => x.CodiceArticolo,
                typeof(FatturaElettronica.Validators.CodiceArticoloValidator));
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
            Validator.ShouldHaveChildValidator(x => x.ScontoMaggiorazione,
                typeof(Validators.ScontoMaggiorazioneValidator));
        }

        [TestMethod]
        public void ScontoMaggiorazioneCollectionCanBeEmpty()
        {
            AssertCollectionCanBeEmpty(x => x.ScontoMaggiorazione);
        }

        [TestMethod]
        public void PrezzoTotaleValidatesAgainstError00423()
        {
            Challenge.PrezzoUnitario = 13.4426m;
            Challenge.Quantita = 2;
            Challenge.PrezzoTotale = 26.89m;
            var result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoUnitario = 3.0246m;
            Challenge.Quantita = 5;
            Challenge.PrezzoTotale = 15.12m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoUnitario = 5.7377m;
            Challenge.Quantita = 0.2m;
            Challenge.PrezzoTotale = 1.15m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoUnitario = 0.0492m;
            Challenge.Quantita = 4;
            Challenge.PrezzoTotale = 0.20m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoUnitario = 22;
            Challenge.Quantita = 4;
            Challenge.PrezzoTotale = 88;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoUnitario = 9.2425m;
            Challenge.Quantita = 4;
            Challenge.PrezzoTotale = 36.97m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoUnitario = 12.235m;
            Challenge.Quantita = 1;
            Challenge.PrezzoTotale = 12.24m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoUnitario = 19.30m;
            Challenge.Quantita = 1;
            Challenge.ScontoMaggiorazione.Add(
                new() { Tipo = "SC", Percentuale = 15m });
            Challenge.PrezzoTotale = 16.41m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoUnitario = 20.5m;
            Challenge.Quantita = 2;
            Challenge.PrezzoTotale = 42;
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.PrezzoTotale).WithErrorCode("00423");

            // https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/181
            Challenge.ScontoMaggiorazione.Clear();
            Challenge.PrezzoUnitario = 0.030987m;
            Challenge.Quantita = 22633;
            Challenge.PrezzoTotale = 701.34m;
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.PrezzoTotale).WithErrorCode("00423");

            // https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/45
            Challenge.ScontoMaggiorazione.Clear();
            Challenge.PrezzoUnitario = 0.865951m;
            Challenge.Quantita = 98;
            Challenge.PrezzoTotale = 84.863198m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            // https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/66
            Challenge.PrezzoUnitario = 20.5m;
            Challenge.Quantita = 1;
            Challenge.PrezzoTotale = 20.5m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoTotale = 20.51m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoTotale = 20.52m;
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.PrezzoTotale).WithErrorCode("00423");

            Challenge.PrezzoTotale = 20.49m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            Challenge.PrezzoTotale = 20.48m;
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.PrezzoTotale).WithErrorCode("00423");

            // https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/71
            Challenge.ScontoMaggiorazione.Clear();
            Challenge.ScontoMaggiorazione.Add(
                new() { Importo = 0, Tipo = "SC" });
            Challenge.PrezzoUnitario = 1m;
            Challenge.Quantita = 1;
            Challenge.PrezzoTotale = 1m;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            //numero massimo di decimali
            Challenge.ScontoMaggiorazione.Clear();
            Challenge.PrezzoUnitario = 0.12345678m;
            Challenge.Quantita = 1000000000;
            Challenge.PrezzoTotale = Challenge.PrezzoUnitario * Challenge.Quantita.Value;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.PrezzoTotale);

            //Errore 00423 per prezzo unitario per arrotondamento
            Challenge.ScontoMaggiorazione.Clear();
            Challenge.PrezzoUnitario = 0.123456789m;
            Challenge.Quantita = 10000000000;
            Challenge.PrezzoTotale = Challenge.PrezzoUnitario * Challenge.Quantita.Value;
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.PrezzoTotale).WithErrorCode("00423");
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
        public void NaturaValidateAgainstError00400()
        {
            Challenge.AliquotaIVA = 0;
            Challenge.Natura = string.Empty;
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Natura).WithErrorCode("00400");

            Challenge.AliquotaIVA = 0;
            Challenge.Natura = null;
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Natura).WithErrorCode("00400");

            Challenge.AliquotaIVA = 22m;
            Challenge.Natura = string.Empty;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Natura);
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
            Validator.ShouldHaveChildValidator(x => x.AltriDatiGestionali,
                typeof(FatturaElettronica.Validators.AltriDatiGestionaliValidator));
        }

        [TestMethod]
        public void AltriDatiGestionaliCollectionCanBeEmpty()
        {
            AssertCollectionCanBeEmpty(x => x.AltriDatiGestionali);
        }

        [TestMethod]
        public void QuantitaIsOptional()
        {
            AssertOptional(x => x.Quantita);
        }

        [TestMethod]
        public void QuantitaCannotBeNegative()
        {
            Challenge.Quantita = -1;
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Quantita);

            Challenge.Quantita = 0;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Quantita);
        }

        [TestMethod]
        public void PrezzoUnitario()
        {
            AssertDecimalType(x => x.PrezzoUnitario, 8, 19);
        }
    }
}