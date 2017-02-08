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
            validator.ShouldHaveChildValidator(
                x => x.DatiOrdineAcquisto, typeof(FatturaElettronica.Validators.DatiOrdineAcquistoValidator));
        }
    }
}
