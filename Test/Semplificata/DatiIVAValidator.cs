namespace Semplificata.Tests
{
    using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
    using global::Tests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DatiIVAValidator : BaseClass<DatiIVA, FatturaElettronica.Validators.Semplificata.DatiIVAValidator>
    {
        [TestMethod]
        public void ImpostaIsOptional()
        {
            AssertOptional(x => x.Imposta);
        }

        [TestMethod]
        public void AliquotaIsOptional()
        {
            AssertOptional(x => x.Aliquota);
        }
    }
}
