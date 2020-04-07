using System.Linq;
using FatturaElettronica.Semplificata.FatturaElettronicaBody;
using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiGenerali;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Semplificata.Tests
{
    [TestClass]
    public class DatiGeneraliDocumentoValidator
        : BaseClass<DatiGeneraliDocumento, FatturaElettronica.Validators.Semplificata.DatiGeneraliDocumentoValidator>
    {
        [TestMethod]
        public void BolloVirtualeIsOptional()
        {
            AssertOptional(x=>x.BolloVirtuale, emptyStringAllowed:false);
        }
        [TestMethod]
        public void BolloVirtualeOnlyAcceptsSIValue()
        {
            AssertOnlyAcceptsSIValue(x=>x.BolloVirtuale);
        }
    }
}
