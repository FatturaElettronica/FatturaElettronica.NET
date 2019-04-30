using System.Linq;
using FatturaElettronica.Semplificata.FatturaElettronicaBody;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Semplificata.Tests
{
    [TestClass]
    public class FatturaElettronicaBodyValidator
        : BaseClass<FatturaElettronicaBody, FatturaElettronica.Validators.Semplificata.FatturaElettronicaBodyValidator>
    {
        [TestMethod]
        [System.Obsolete]
        public void DatiGeneraliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, typeof(FatturaElettronica.Validators.Semplificata.DatiGeneraliValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void DatiBeniServiziHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiBeniServizi, typeof(FatturaElettronica.Validators.Semplificata.DatiBeniServiziValidator));
        }
        [TestMethod]
        public void DatiBeniServiziCannotBeEmpty()
        {
            var r = validator.Validate(challenge);
            Assert.AreEqual("DatiBeniServizi è obbligatorio", r.Errors.FirstOrDefault(x => x.PropertyName == "DatiBeniServizi").ErrorMessage);
        }
        [TestMethod]
        [System.Obsolete]
        public void AllegatiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.Allegati, typeof(FatturaElettronica.Validators.Semplificata.AllegatiValidator));
        }
    }
}
