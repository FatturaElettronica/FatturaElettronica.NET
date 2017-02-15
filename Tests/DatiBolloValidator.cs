using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiBolloValidator
        : BaseClass<DatiBollo, FatturaElettronica.Validators.DatiBolloValidator>
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
        public void ImportoBolloIsRequired()
        {
            // Abbiamo bisogno di istanza non Empty ma in questo caso non possiamo usare CausalePagamento
            // a tal scopo perché dobbiamo testare proprio quella proprietà.
            challenge.BolloVirtuale = "hello";

            AssertRequired(x => x.ImportoBollo);
        }
        [TestMethod]
        public void BolloVirtualeIsRequired()
        {
            AssertRequired(x => x.BolloVirtuale);
        }
        [TestMethod]
        public void BolloVirtualeOnlyAcceptsSIValue()
        {
            AssertOnlyAcceptsSIValue(x => x.BolloVirtuale);
        }
    }
}
