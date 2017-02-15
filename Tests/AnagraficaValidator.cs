using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Common;

namespace Tests
{
    [TestClass]
    public class AnagraficaValidator 
        : DenominazioneNomeCognomeValidator<Anagrafica, FatturaElettronica.Validators.AnagraficaValidator>
    {
        [TestMethod]
        public void TitoloIsOptional()
        {
            AssertOptional(x => x.Titolo);
        }
        [TestMethod]
        public void TitoloMinMaxLength()
        {
            AssertMinMaxLength(x => x.Titolo, 2, 10);
        }
        [TestMethod]
        public void CodEORIsOptional()
        {
            AssertOptional(x => x.CodEORI);
        }
        [TestMethod]
        public void CodEORIMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodEORI, 13, 17);
        }
    }
}
