using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiBolloValidator
        : BaseClass<DatiBollo, FatturaElettronica.Validators.DatiBolloValidator>
    {
        [TestMethod]
        public void ImportoBolloIsRequired()
        {
            AssertRequired(x => x.ImportoBollo);
        }
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
