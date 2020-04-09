using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using System;
using System.Linq;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiGeneraliValidator : BaseClass<DatiGenerali, FatturaElettronica.Validators.DatiGeneraliValidator>
    {
        [TestMethod]
        public void DatiGeneraliDocumentoHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DatiGeneraliDocumento, typeof(FatturaElettronica.Validators.DatiGeneraliDocumentoValidator));
        }

        [TestMethod]
        public void DatiGeneraliDocumentoCannotPredateDatiFattureCollegate()
        {
            Challenge.DatiGeneraliDocumento.Data = DateTime.Now.AddDays(-1);
            Challenge.DatiFattureCollegate.Add(
                new DatiFattureCollegate {Data = DateTime.Now});

            var r = Validator.Validate(Challenge);
            Assert.IsFalse(r.IsValid);

            Assert.AreEqual("00418",
                r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGeneraliDocumento.Data")?.ErrorCode);

            Challenge.DatiGeneraliDocumento.Data = DateTime.Now;
            r = Validator.Validate(Challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGeneraliDocumento.Data"));
        }

        [TestMethod]
        public void DatiOrdineAcquistoHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiOrdineAcquisto,
                typeof(Validators.DatiOrdineAcquistoValidator));
        }

        [TestMethod]
        public void DatiContrattoHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiContratto,
                typeof(FatturaElettronica.Validators.DatiContrattoValidator));
        }

        [TestMethod]
        public void DatiConvenzioneHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiConvenzione,
                typeof(FatturaElettronica.Validators.DatiConvenzioneValidator));
        }

        [TestMethod]
        public void DatiRicezioneHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiRicezione,
                typeof(FatturaElettronica.Validators.DatiRicezioneValidator));
        }

        [TestMethod]
        public void DatiFattureCollegateHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiFattureCollegate,
                typeof(FatturaElettronica.Validators.DatiFattureCollegateValidator));
        }

        [TestMethod]
        public void DatiDDTHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiDDT, typeof(FatturaElettronica.Validators.DatiDDTValidator));
        }

        [TestMethod]
        public void DatiTrasportoHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(x => x.DatiTrasporto,
                typeof(FatturaElettronica.Validators.DatiTrasportoValidator));
        }

        [TestMethod]
        public void FatturaPrincipaleHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(x => x.FatturaPrincipale,
                typeof(FatturaElettronica.Validators.FatturaPrincipaleValidator));
        }
    }
}