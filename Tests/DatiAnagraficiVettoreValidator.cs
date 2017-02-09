using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiAnagraficiVettoreValidator : BaseDatiAnagraficiValidator<DatiAnagraficiVettore, FatturaElettronica.Validators.DatiAnagraficiVettoreValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            base.Init();

            // Abbiamo bisogno che l'istanza non sia Empty.
            challenge.Anagrafica.Cognome = "x";
        }
        [TestMethod]
        public void ValidationIsPerformedWhenNotEmpty()
        {
            var r = validator.Validate(challenge);
            Assert.IsFalse(r.IsValid);
        }

        [TestMethod]
        public void IsValidWhenEmptyBecauseOptional()
        {
            // Riportiamo istanza a Empty (vedi Init()).
            challenge.Anagrafica.Cognome = null;

            var r = validator.Validate(challenge);
            Assert.IsTrue(r.IsValid);
        }
        [TestMethod]
        public void NumeroLicenzaGuidaCanBeEmpty()
        {
            challenge.NumeroLicenzaGuida = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroLicenzaGuida, challenge);
            challenge.NumeroLicenzaGuida = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroLicenzaGuida, challenge);
        }
        [TestMethod]
        public void NumeroLicenzaGuidaMinMaxLength()
        {
            challenge.NumeroLicenzaGuida = new string('x', 21);
            validator.ShouldHaveValidationErrorFor(x => x.NumeroLicenzaGuida, challenge);
            challenge.NumeroLicenzaGuida = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroLicenzaGuida, challenge);
            challenge.NumeroLicenzaGuida = new string('x', 20);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroLicenzaGuida, challenge);
        }

        // Questi test della Base class non devono essere eseuigiti per DatiAnagraficiVettore.
        // Preferisco non usare Ignore perché risulterebbero Skipped. La soluzione attuale
        // è non decorarli con TestMethod. In questo modo non sono test (solo per questa classe),
        // che è esattamente quel che voglio senza essere costrettoa rinunciare al DRY offerto 
        // dalla Base class.

        //[TestMethod]
        //[Ignore]
        public new void IdFiscaleIVAHasChildValidator() { }
        //[TestMethod]
        //[Ignore]
        public new void AnagraficaHasChildValidator() { }
    }
}
