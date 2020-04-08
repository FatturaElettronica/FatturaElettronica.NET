using FluentValidation.TestHelper;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiBeniServiziValidator
        : BaseClass<DatiBeniServizi, FatturaElettronica.Validators.DatiBeniServiziValidator>
    {
        [TestMethod]
        public void DettaglioLineeHasCollectionValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DettaglioLinee, typeof(FatturaElettronica.Validators.DettaglioLineeValidator));
        }
        [TestMethod]
        public void DettaglioLineeCollectionCannotBeEmpty()
        {
            var r = Validator.Validate(Challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DettaglioLinee"));

            Challenge.DettaglioLinee.Add(new DettaglioLinee());
            r = Validator.Validate(Challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DettaglioLinee"));
        }
        [TestMethod]
        public void DatiRiepilogoCollectionValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DatiRiepilogo, typeof(FatturaElettronica.Validators.DatiRiepilogoValidator));
        }
        [TestMethod]
        public void DatiRiepilogoCollectionCannotBeEmpty()
        {
            AssertCollectionCannotBeEmpty(x => x.DatiRiepilogo);
        }
    }
}
