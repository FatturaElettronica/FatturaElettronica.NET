using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiGenerali;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class DatiGeneraliDocumentoValidator
        : BaseClass<DatiGeneraliDocumento, FatturaElettronica.Validators.Semplificata.DatiGeneraliDocumentoValidator>
    {
        [TestMethod]
        public void BolloVirtualeIsOptional()
        {
            AssertOptional(x => x.BolloVirtuale, emptyStringAllowed: false);
        }

        [TestMethod]
        public void BolloVirtualeOnlyAcceptsSIValue()
        {
            AssertOnlyAcceptsSIValue(x => x.BolloVirtuale);
        }
    }
}