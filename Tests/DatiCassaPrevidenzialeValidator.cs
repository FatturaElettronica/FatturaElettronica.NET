using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace Tests
{
    [TestClass]
    public class DatiCassaPrevidenzialeValidator
        : BaseClass<DatiCassaPrevidenziale, FatturaElettronica.Validators.DatiCassaPrevidenzialeValidator>
    {
        [TestMethod]
        public void TipoCassaIsRequired()
        {
            AssertRequired(x => x.TipoCassa);
        }
        [TestMethod]
        public void TipoCassaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<TipoCassa>(x => x.TipoCassa);
        }
        [TestMethod]
        public void NaturaIsRequired()
        {
            AssertRequired(x => x.Natura);
        }
        [TestMethod]
        public void NaturaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<Natura>(x => x.Natura);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneIsOptional()
        {
            AssertOptional(x => x.RiferimentoAmministrazione);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneMinMaxLength()
        {
            AssertMinMaxLength(x => x.RiferimentoAmministrazione, 1, 20);
        }
        [TestMethod]
        public void RitenutaIsOptional()
        {
            AssertOptional(x => x.Ritenuta);
        }
        [TestMethod]
        public void RitenutaOnlyAcceptSIValue()
        {
            AssertOnlyAcceptsSIValue(x => x.Ritenuta);
        }
    }
}
