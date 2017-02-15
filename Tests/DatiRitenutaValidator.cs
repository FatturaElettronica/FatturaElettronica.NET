using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace Tests
{
    [TestClass]
    public class DatiRitenutaValidator: BaseClass<DatiRitenuta, FatturaElettronica.Validators.DatiRitenutaValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            base.Init();

            // Abbiamo bisogno che l'istanza non sia Empty.
            challenge.CausalePagamento = "hello";

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
            challenge.CausalePagamento = null;

            var r = validator.Validate(challenge);
            Assert.IsTrue(r.IsValid);
        }
        [TestMethod]
        public void TipoRitenutaIsRequired()
        {
            AssertRequired(x => x.TipoRitenuta);
        }
        [TestMethod]
        public void TipoRitenutaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<TipoRitenuta>(x => x.TipoRitenuta);
        }
        [TestMethod]
        public void ImportoRitenutaIsRequired()
        {
            AssertRequired(x => x.ImportoRitenuta);
        }
        [TestMethod]
        public void AliquotaRitenutaIsRequired()
        {
            AssertRequired(x => x.AliquotaRitenuta);
        }
        [TestMethod]
        public void CausalePagamentoIsRequired()
        {
            // Abbiamo bisogno di istanza non Empty ma in questo caso non possiamo usare CausalePagamento
            // a tal scopo perché dobbiamo testare proprio quella proprietà.
            challenge.ImportoRitenuta = 1;

            AssertRequired(x => x.CausalePagamento);
        }
        [TestMethod]
        public void CausalePagamentoOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<CausalePagamento>(x => x.CausalePagamento);
        }
    }
}
