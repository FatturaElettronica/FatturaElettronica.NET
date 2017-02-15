using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiVeicoli;

namespace Tests
{
    [TestClass]
    public class DatiVeicoliValidator: BaseClass<DatiVeicoli, FatturaElettronica.Validators.DatiVeicoliValidator>
    {
        [TestMethod]
        public void TotalePercorsoIsRequired()
        {
            AssertRequired(x => x.TotalePercorso);
        }
        [TestMethod]
        public void TotalePercorsoMinMaxLength()
        {
            AssertMinMaxLength(x => x.TotalePercorso, 1, 15);
        }
        [TestMethod]
        public void DataIsRequired()
        {
            AssertRequired(x => x.Data);
        }
    }
}
