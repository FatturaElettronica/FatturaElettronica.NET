using FatturaElettronica.Tabelle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiAnagraficiCedentePrestatoreValidator 
        : BaseDatiAnagraficiValidator<FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore.DatiAnagraficiCedentePrestatore, FatturaElettronica.Validators.DatiAnagraficiCedentePrestatoreValidator>
    {
        [TestMethod]
        public void AlboProfessionalIsOptional()
        {
            AssertOptional(x => x.AlboProfessionale);
        }
        [TestMethod]
        public void AlboProfessionaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.AlboProfessionale, 1, 60);
        }
        [TestMethod]
        public void ProvinciaAlboIsOptional()
        {
            AssertOptional(x => x.ProvinciaAlbo);
        }
        [TestMethod]
        public void ProvinciaAlboOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<Provincia>(x => x.ProvinciaAlbo);
        }
        [TestMethod]
        public void NumeroIscrizioneAlboIsOptional()
        {
            AssertOptional(x => x.NumeroIscrizioneAlbo);
        }
        [TestMethod]
        public void NumeroIscrizioneAlboMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroIscrizioneAlbo, 1, 60);
        }
        [TestMethod]
        public void RegimeFiscaleIsRequired()
        {
            AssertRequired(x => x.RegimeFiscale);
        }
        [TestMethod]
        public void RegimeFiscaleOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<RegimeFiscale>(x => x.RegimeFiscale);
        }
    }
}
