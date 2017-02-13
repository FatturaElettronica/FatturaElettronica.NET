using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;
using System.Linq;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class FatturaElettronicaBodyValidator: BaseClass<FatturaElettronicaBody, FatturaElettronica.Validators.FatturaElettronicaBodyValidator>
    {
        [TestMethod]
        public void DatiGeneraliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, typeof(FatturaElettronica.Validators.DatiGeneraliValidator));
        }
        public void DatiBeniServiziHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiBeniServizi, typeof(FatturaElettronica.Validators.DatiBeniServiziValidator));
        }
        [TestMethod]
        public void DatiRitenutaValidateAgainstError00411()
        {
            challenge.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { Ritenuta = "SI" });
            var r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGenerali.DatiGeneraliDocumento.DatiRitenuta"));

            challenge.DatiBeniServizi.DettaglioLinee[0].Ritenuta = null;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiGenerali.DatiGeneraliDocumento.DatiRitenuta"));
        }
    }
}
