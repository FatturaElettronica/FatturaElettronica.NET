using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
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
        public void NumeroLicenzaIsOptional()
        {
            AssertOptional(x => x.NumeroLicenzaGuida);
        }
        [TestMethod]
        public void NumeroLicenzaGuidaMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroLicenzaGuida, 1, 20);
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
