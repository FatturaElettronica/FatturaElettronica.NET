using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiRitenutaValidator : BaseClass<DatiRitenuta, FatturaElettronica.Validators.DatiRitenutaValidator>
    {
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
        public void CausalePagamentoIsRequired()
        {
            AssertRequired(x => x.CausalePagamento);
        }

        [TestMethod]
        public void CausalePagamentoOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<CausalePagamento>(x => x.CausalePagamento);
        }
    }
}