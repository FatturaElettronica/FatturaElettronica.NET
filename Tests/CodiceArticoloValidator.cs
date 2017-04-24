using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;

namespace Tests
{
    [TestClass]
    public class CodiceArticoloValidator
        : BaseClass<CodiceArticolo, FatturaElettronica.Validators.CodiceArticoloValidator>
    {
        [TestMethod]
        public void CodiceTipoIsRequired()
        {
            AssertRequired(x => x.CodiceTipo);
        }
        [TestMethod]
        public void CodiceTipoMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceTipo, 1, 35);
        }
        [TestMethod]
        public void CodiceTipoMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.CodiceTipo);
        }
        [TestMethod]
        public void CodiceValoreIsRequired()
        {
            AssertRequired(x => x.CodiceValore);
        }
        [TestMethod]
        public void CodiceValoreMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceValore, 1, 35);
        }
        [TestMethod]
        public void CodiceValoreMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.CodiceValore);
        }
    }
}
