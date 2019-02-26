namespace Ordinaria.Tests
{
    using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiVeicoli;
    using global::Tests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DatiVeicoliValidator : BaseClass<DatiVeicoli, FatturaElettronica.Validators.DatiVeicoliValidator>
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
        public void TotalePercorsoMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.TotalePercorso);
        }
        [TestMethod]
        public void DataIsRequired()
        {
            AssertRequired(x => x.Data);
        }
    }
}
