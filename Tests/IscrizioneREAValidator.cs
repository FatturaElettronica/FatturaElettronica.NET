using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica.Tabelle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class IscrizioneREAValidator 
        : BaseClass<IscrizioneREA, FatturaElettronica.Validators.IscrizioneREAValidator>
    {
        [TestMethod]
        public void UfficioIsRequired()
        {
            AssertRequired(x => x.Ufficio);
        }
        [TestMethod]
        public void UfficioOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<Provincia>(x => x.Ufficio);
        }
        [TestMethod]
        public void NumeroREAIsRequired()
        {
            AssertRequired(x => x.NumeroREA);
        }
        [TestMethod]
        public void NumeroREAMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroREA, 1, 20);
        }
        [TestMethod]
        public void NumeroREAMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.NumeroREA);
        }
        [TestMethod]
        public void SocioUnicoIsOptional()
        {
            AssertOptional(x => x.SocioUnico);
        }
        [TestMethod]
        public void SocioUnicoOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<SocioUnico>(x => x.SocioUnico);
        }
        [TestMethod]
        public void StatoLiquidazioneIsRequired()
        {
            AssertRequired(x => x.StatoLiquidazione);
        }
        [TestMethod]
        public void StatoLiquidazioneOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<StatoLiquidazione>(x => x.StatoLiquidazione);
        }
    }
}
