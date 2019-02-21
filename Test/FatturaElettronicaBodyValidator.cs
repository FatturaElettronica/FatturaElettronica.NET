namespace Tests
{
    using System.Linq;
    using FatturaElettronica.Ordinaria.FatturaElettronicaBody;
    using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;
    using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
    using FluentValidation.TestHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FatturaElettronicaBodyValidator
        : BaseClass<FatturaElettronicaBody, FatturaElettronica.Validators.FatturaElettronicaBodyValidator>
    {
        [TestMethod]
        public void DatiGeneraliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, typeof(FatturaElettronica.Validators.DatiGeneraliValidator));
        }
        [TestMethod]
        public void DatiBeniServiziHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiBeniServizi, typeof(FatturaElettronica.Validators.DatiBeniServiziValidator));
        }
        [TestMethod]
        public void DatiBeniServiziCannotBeEmpty()
        {
            var r = validator.Validate(challenge);
            Assert.AreEqual("DatiBeniServizi è obbligatorio", r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi").ErrorMessage);
        }
        [TestMethod]
        public void DatiRitenutaValidateAgainstError00411()
        {
            challenge.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { Ritenuta = "SI" });
            var r = validator.Validate(challenge);
            Assert.AreEqual("00411", r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGenerali.DatiGeneraliDocumento.DatiRitenuta").ErrorCode);

            challenge.DatiBeniServizi.DettaglioLinee[0].Ritenuta = null;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGenerali.DatiGeneraliDocumento.DatiRitenuta"));
        }
        [TestMethod]
        public void DatiRitenutaValidateAgainstError00422()
        {
            challenge.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { AliquotaIVA = 10m, PrezzoTotale = 100m });
            challenge.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { AliquotaIVA = 10m, ImponibileImporto = 101m });
            var r = validator.Validate(challenge);
            Assert.AreEqual("00422", r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi.DatiRiepilogo").ErrorCode);

            challenge.DatiBeniServizi.DatiRiepilogo[0].ImponibileImporto = 100m;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi.DatiRiepilogo"));
        }
        [TestMethod]
        public void DatiRitenutaValidateAgainstError00419()
        {
            challenge.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { AliquotaIVA = 1 });
            challenge.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { AliquotaIVA = 2 });
            challenge.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { AliquotaIVA = 3 });

            challenge.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Add(new DatiCassaPrevidenziale { AliquotaIVA = 4 });

            challenge.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { AliquotaIVA = 1 });
            challenge.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { AliquotaIVA = 2 });
            challenge.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { AliquotaIVA = 3 });
            var r = validator.Validate(challenge);
            Assert.AreEqual("00419", r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi.DatiRiepilogo").ErrorCode);

            challenge.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { AliquotaIVA = 4 });
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi.DatiRiepilogo"));
        }
        [TestMethod]
        public void DatiVeicoliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, typeof(FatturaElettronica.Validators.DatiGeneraliValidator));
        }
        [TestMethod]
        public void DatiPagamentoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiPagamento, typeof(FatturaElettronica.Validators.DatiPagamentoValidator));
        }
        [TestMethod]
        public void AllegatiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.Allegati, typeof(FatturaElettronica.Validators.AllegatiValidator));
        }
    }
}
