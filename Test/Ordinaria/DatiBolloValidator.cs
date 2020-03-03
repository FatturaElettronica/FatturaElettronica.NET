using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using Tests;

namespace Ordinaria.Tests
{
    [TestClass]
    public class DatiBolloValidator
        : BaseClass<DatiBollo, FatturaElettronica.Validators.DatiBolloValidator>
    {
        [TestMethod]
        public void BolloVirtualeIsRequired()
        {
            AssertRequired(x => x.BolloVirtuale);
        }
        [TestMethod]
        public void BolloVirtualeOnlyAcceptsSIValue()
        {
            AssertOnlyAcceptsSIValue(x => x.BolloVirtuale);
        }
    }
}
