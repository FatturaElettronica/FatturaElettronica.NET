using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Test.Ordinaria
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
        
        [TestMethod]
        public void ImportoBollo()
        {
            AssertDecimalType(x => x.ImportoBollo, 2, 13);
        }
    }
}
