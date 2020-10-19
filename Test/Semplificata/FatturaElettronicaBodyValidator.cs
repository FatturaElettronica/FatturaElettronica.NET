using System.Linq;
using FatturaElettronica.Semplificata.FatturaElettronicaBody;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class FatturaElettronicaBodyValidator
        : BaseClass<FatturaElettronicaBody, FatturaElettronica.Validators.Semplificata.FatturaElettronicaBodyValidator>
    {
        [TestMethod]
        public void DatiGeneraliHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, typeof(FatturaElettronica.Validators.Semplificata.DatiGeneraliValidator));
        }

        [TestMethod]
        public void DatiBeniServiziHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DatiBeniServizi, typeof(FatturaElettronica.Validators.Semplificata.DatiBeniServiziValidator));
        }

        [TestMethod]
        public void DatiBeniServiziCannotBeEmpty()
        {
            var r = Validator.Validate(Challenge);
            Assert.AreEqual("DatiBeniServizi è obbligatorio",
                r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi")?.ErrorMessage);
        }

        [TestMethod]
        public void AllegatiHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.Allegati, typeof(FatturaElettronica.Validators.Semplificata.AllegatiValidator));
        }
    }
}