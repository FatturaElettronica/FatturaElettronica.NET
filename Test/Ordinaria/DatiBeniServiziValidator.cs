namespace Ordinaria.Tests
{
    using FluentValidation.TestHelper;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;
    using global::Tests;

    [TestClass]
    public class DatiBeniServiziValidator
        : BaseClass<DatiBeniServizi, FatturaElettronica.Validators.DatiBeniServiziValidator>
    {
        [TestMethod]
        public void DettaglioLineeHasCollectionValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DettaglioLinee, typeof(FatturaElettronica.Validators.DettaglioLineeValidator));
        }
        [TestMethod]
        public void DettaglioLineeCollectionCannotBeEmpty()
        {
            var r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DettaglioLinee"));

            challenge.DettaglioLinee.Add(new DettaglioLinee());
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DettaglioLinee"));
        }
        [TestMethod]
        public void DatiRiepilogoCollectionValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiRiepilogo, typeof(FatturaElettronica.Validators.DatiRiepilogoValidator));
        }
        [TestMethod]
        public void DatiRiepilogoCollectionCannotBeEmpty()
        {
            AssertCollectionCannotBeEmpty(x => x.DatiRiepilogo);
        }
    }
}
