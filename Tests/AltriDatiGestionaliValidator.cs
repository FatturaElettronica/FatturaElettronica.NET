using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;

namespace Tests
{
    [TestClass]
    public class AltriDatiGestionaliValidator
        : BaseClass<AltriDatiGestionali, FatturaElettronica.Validators.AltriDatiGestionaliValidator>
    {
        [TestMethod]
        public void TipoDatoIsRequired()
        {
            AssertRequired(x => x.TipoDato);
        }
        [TestMethod]
        public void TipoDatoMinMaxLength()
        {
            AssertMinMaxLength(x => x.TipoDato, 1, 10);
        }
        [TestMethod]
        public void RiferimentoTestoIsOptional()
        {
            AssertOptional(x => x.RiferimentoTesto);
        }
        [TestMethod]
        public void RiferimentoTestoMinMaxLength()
        {
            AssertMinMaxLength(x => x.RiferimentoTesto, 1, 60);
        }
    }
}
