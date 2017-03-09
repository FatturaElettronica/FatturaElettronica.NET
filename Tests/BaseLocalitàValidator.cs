using FatturaElettronica.Tabelle;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public abstract class BaseLocalitàValidator<TClass, TValidator> 
        : BaseClass<TClass, TValidator> 
        where TClass : FatturaElettronica.Common.Località
        where TValidator : IValidator<TClass>

    {
        [TestMethod]
        public void IndirizzoIsRequired()
        {
            AssertRequired(x => x.Indirizzo);
        }
        [TestMethod]
        public void IndirizzoMinMaxLength()
        {
            AssertMinMaxLength(x => x.Indirizzo, 1, 60);
        }
        [TestMethod]
        public void NumeroCivicoIsOptional()
        {
            AssertOptional(x => x.NumeroCivico);
        }
        [TestMethod]
        public void NumeroCivicoMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroCivico, 1, 8);
        }
        [TestMethod]
        public void CAPIsRequired()
        {
            AssertRequired(x => x.CAP);
        }
        [TestMethod]
        public void CAPLength()
        {
            AssertLength(x => x.CAP, 5);
        }
        [TestMethod]
        public void ComuneIsRequired()
        {
            AssertRequired(x => x.Comune);
        }
        [TestMethod]
        public void ComuneMinMaxLength()
        {
            AssertMinMaxLength(x => x.Comune, 1, 60);
        }
        [TestMethod]
        public void ProvinciaOptional()
        {
            AssertOptional(x => x.Provincia);
        }
        [TestMethod]
        public void ProvinciaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<Provincia>(x => x.Provincia);
        }
        [TestMethod]
        public void NazioneIsRequired()
        {
            AssertRequired(x => x.Nazione);
        }
        [TestMethod]
        public void NazioneOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<IdPaese>(x => x.Nazione);
        }
    }
}
