using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiDDTValidator
        : BaseClass<DatiDDT, FatturaElettronica.Validators.DatiDDTValidator>
    {
        [TestMethod]
        public void NumeroDDTIsRequired()
        {
            AssertRequired(x => x.NumeroDDT);
        }
        [TestMethod]
        public void NumeroDDTMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroDDT, 1, 20);
        }
        [TestMethod]
        public void NumeroDDTMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.NumeroDDT);
        }
    }
}
