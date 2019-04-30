using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using System;
using System.Linq;
using Tests;

namespace Ordinaria.Tests
{
    [TestClass]
    public class DatiGeneraliValidator : BaseClass<DatiGenerali, FatturaElettronica.Validators.DatiGeneraliValidator>
    {
        [TestMethod]
        [Obsolete]
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

            Assert.AreEqual("00418", r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGeneraliDocumento.Data").ErrorCode);

            challenge.DatiGeneraliDocumento.Data = DateTime.Now;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGeneraliDocumento.Data"));
        }
        [TestMethod]
        [Obsolete]
        public void DatiOrdineAcquistoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiOrdineAcquisto, typeof(FatturaElettronica.Validators.DatiOrdineAcquistoValidator));
        }
        [TestMethod]
        [Obsolete]
        public void DatiContrattoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiContratto, childValidatorType: typeof(FatturaElettronica.Validators.DatiContrattoValidator));
        }
        [TestMethod]
        [Obsolete]
        public void DatiConvenzioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiConvenzione, typeof(FatturaElettronica.Validators.DatiConvenzioneValidator));
        }
        [TestMethod]
        [Obsolete]
        public void DatiRicezioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiRicezione, typeof(FatturaElettronica.Validators.DatiRicezioneValidator));
        }
        [TestMethod]
        [Obsolete]
        public void DatiFattureCollegateHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiFattureCollegate, typeof(FatturaElettronica.Validators.DatiFattureCollegateValidator));
        }
        [TestMethod]
        [Obsolete]
        public void DatiDDTHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiDDT, typeof(FatturaElettronica.Validators.DatiDDTValidator));
        }
        [TestMethod]
        [Obsolete]
        public void DatiTrasportoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiTrasporto, typeof(FatturaElettronica.Validators.DatiTrasportoValidator));
        }
        [TestMethod]
        [Obsolete]
        public void FatturaPrincipaleHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.FatturaPrincipale, typeof(FatturaElettronica.Validators.FatturaPrincipaleValidator));
        }
    }
}
