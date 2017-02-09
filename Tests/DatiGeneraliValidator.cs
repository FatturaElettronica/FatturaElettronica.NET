using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DatiGeneraliValidator: BaseClass<DatiGenerali, FatturaElettronica.Validators.DatiGeneraliValidator>
    {
        [TestMethod]
        public void DatiGeneraliDocumentoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiGeneraliDocumento, typeof(FatturaElettronica.Validators.DatiGeneraliDocumentoValidator));
        }
        [TestMethod]
        public void DatiGeneraliDocumentoCannotPredateDatiFattureCollegate()
        {
            challenge.DatiGeneraliDocumento.Data = DateTime.Now.AddDays(-1);
            challenge.DatiFattureCollegate.Add(
                new DatiFattureCollegate { Data = DateTime.Now });

            var r = validator.Validate(challenge);
            Assert.IsFalse(r.IsValid);

            // For some reason this does not work (I suspect because property name is dotted)
            // TODO consider implementing an extension method for this
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGeneraliDocumento.Data"));

            challenge.DatiGeneraliDocumento.Data = DateTime.Now;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGeneraliDocumento.Data"));
        }
        [TestMethod]
        public void DatiOrdineAcquistoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiOrdineAcquisto, typeof(FatturaElettronica.Validators.DatiOrdineAcquistoValidator));
        }
        [TestMethod]
        public void DatiContrattoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiContratto, typeof(FatturaElettronica.Validators.DatiContrattoValidator));
        }
        [TestMethod]
        public void DatiConvenzioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiConvenzione, typeof(FatturaElettronica.Validators.DatiConvenzioneValidator));
        }
        [TestMethod]
        public void DatiRicezioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiRicezione, typeof(FatturaElettronica.Validators.DatiRicezioneValidator));
        }
        [TestMethod]
        public void DatiFattureCollegateHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiFattureCollegate, typeof(FatturaElettronica.Validators.DatiFattureCollegateValidator));
        }
        [TestMethod]
        public void DatiDDTHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiDDT, typeof(FatturaElettronica.Validators.DatiDDTValidator));
        }
        [TestMethod]
        public void DatiTrasportoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiTrasporto, typeof(FatturaElettronica.Validators.DatiTrasportoValidator));
        }
    }
}
