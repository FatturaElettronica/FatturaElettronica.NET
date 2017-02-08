using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiBolloValidator: BaseClass<DatiBollo, FatturaElettronica.Validators.DatiBolloValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            base.Init();

            // Abbiamo bisogno che l'istanza non sia Empty.
            challenge.ImportoBollo = 1;

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
            challenge.ImportoBollo = null;

            var r = validator.Validate(challenge);
            Assert.IsTrue(r.IsValid);
        }
        [TestMethod]
        public void ImportoBolloCannotBeNull()
        {
            // Abbiamo bisogno di istanza non Empty ma in questo caso non possiamo usare CausalePagamento
            // a tal scopo perché dobbiamo testare proprio quella proprietà.
            challenge.BolloVirtuale = "hello";

            challenge.ImportoBollo = null;
            validator.ShouldHaveValidationErrorFor(x => x.ImportoBollo, challenge);
            challenge.ImportoBollo = 0;
            validator.ShouldNotHaveValidationErrorFor(x => x.ImportoBollo, challenge);
        }
        [TestMethod]
        public void BolloVirtualeCannotBeEmpty()
        {
            challenge.BolloVirtuale = null;
            validator.ShouldHaveValidationErrorFor(x => x.BolloVirtuale, challenge);
            challenge.BolloVirtuale = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.BolloVirtuale, challenge);
        }
        [TestMethod]
        public void BolloVirtualCanOnlyAcceptSIValue()
        {
            challenge.BolloVirtuale = "NO";
            validator.ShouldHaveValidationErrorFor(x => x.BolloVirtuale, challenge);
            challenge.BolloVirtuale = "SI";
            validator.ShouldNotHaveValidationErrorFor(x => x.BolloVirtuale, challenge);
        }
    }
}
