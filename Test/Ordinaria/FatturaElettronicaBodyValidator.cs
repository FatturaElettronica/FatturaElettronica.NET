using System.Linq;
using FatturaElettronica.Extensions;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody;
using FatturaElettronica.Resources;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class FatturaElettronicaBodyValidator
        : BaseClass<FatturaElettronicaBody, FatturaElettronica.Validators.FatturaElettronicaBodyValidator>
    {
        [TestMethod]
        public void DatiGeneraliHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, typeof(FatturaElettronica.Validators.DatiGeneraliValidator));
        }

        [TestMethod]
        public void DatiBeniServiziHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DatiBeniServizi, typeof(FatturaElettronica.Validators.DatiBeniServiziValidator));
        }

        [TestMethod]
        public void DatiBeniServiziCannotBeEmpty()
        {
            var r = Validator.Validate(Challenge);
            Assert.AreEqual(ValidatorMessages.DatiBeniServiziEObbligatorio,
                r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi")?.ErrorMessage);
        }

        [TestMethod]
        public void TipoDocumentoValidateAgainstError00474()
        {
            Challenge.DatiGenerali.DatiGeneraliDocumento.TipoDocumento = "TD21";
            Challenge.DatiBeniServizi.DettaglioLinee.Add(new() {AliquotaIVA = 1m});
            Challenge.DatiBeniServizi.DettaglioLinee.Add(new() {AliquotaIVA = 0m});

            Assert.IsNotNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00474"));

            Challenge.DatiGenerali.DatiGeneraliDocumento.TipoDocumento = "TD01";
            Assert.IsNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00474"));

            Challenge.DatiGenerali.DatiGeneraliDocumento.TipoDocumento = "TD21";
            Challenge.DatiBeniServizi.DettaglioLinee[1].AliquotaIVA = 2m;
            Assert.IsNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00474"));
        }

        [TestMethod]
        public void DatiRitenutaValidateAgainstError00411()
        {
            Challenge.DatiBeniServizi.DettaglioLinee.Add(new() {Ritenuta = "SI"});
            var r = Validator.Validate(Challenge);
            Assert.AreEqual("00411",
                r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGenerali.DatiGeneraliDocumento.DatiRitenuta")
                    ?.ErrorCode);

            Challenge.DatiBeniServizi.DettaglioLinee[0].Ritenuta = null;
            r = Validator.Validate(Challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x =>
                x.PropertyName == "DatiGenerali.DatiGeneraliDocumento.DatiRitenuta"));
        }

        [TestMethod]
        public void DatiRitenutaValidateAgainstError00422()
        {
            Challenge.DatiBeniServizi.DettaglioLinee.Add(new() {AliquotaIVA = 10m, PrezzoTotale = 100m});
            Challenge.DatiBeniServizi.DatiRiepilogo.Add(new()
            {
                AliquotaIVA = 10m, ImponibileImporto = 101m
            });
            var r = Validator.Validate(Challenge);
            Assert.AreEqual("00422",
                r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi.DatiRiepilogo")?.ErrorCode);

            Challenge.DatiBeniServizi.DatiRiepilogo[0].ImponibileImporto = 100m;
            r = Validator.Validate(Challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi.DatiRiepilogo"));
        }

        [TestMethod]
        public void DatiRitenutaValidateAgainstError00419()
        {
            Challenge.DatiBeniServizi.DettaglioLinee.Add(new() {AliquotaIVA = 1});
            Challenge.DatiBeniServizi.DettaglioLinee.Add(new() {AliquotaIVA = 2});
            Challenge.DatiBeniServizi.DettaglioLinee.Add(new() {AliquotaIVA = 3});

            Challenge.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Add(
                new() {AliquotaIVA = 4});

            Challenge.DatiBeniServizi.DatiRiepilogo.Add(new() {AliquotaIVA = 1});
            Challenge.DatiBeniServizi.DatiRiepilogo.Add(new() {AliquotaIVA = 2});
            Challenge.DatiBeniServizi.DatiRiepilogo.Add(new() {AliquotaIVA = 3});
            var r = Validator.Validate(Challenge);
            Assert.AreEqual("00419",
                r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi.DatiRiepilogo")?.ErrorCode);

            Challenge.DatiBeniServizi.DatiRiepilogo.Add(new() {AliquotaIVA = 4});
            r = Validator.Validate(Challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi.DatiRiepilogo"));
        }

        [TestMethod]
        public void DatiVeicoliHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, typeof(FatturaElettronica.Validators.DatiGeneraliValidator));
        }

        [TestMethod]
        public void DatiPagamentoHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DatiPagamento, typeof(FatturaElettronica.Validators.DatiPagamentoValidator));
        }

        [TestMethod]
        public void AllegatiHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.Allegati, typeof(FatturaElettronica.Validators.AllegatiValidator));
        }
    }
}
