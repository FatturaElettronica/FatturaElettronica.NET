using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
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
        public void TipoDatoMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.TipoDato);
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

        [TestMethod]
        public void RiferimentoTestoMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.RiferimentoTesto);
        }
        
        [TestMethod]
        public void RiferimentoNumero()
        {
            AssertDecimalType(x => x.RiferimentoNumero, 8, 19);
        }
    }
}