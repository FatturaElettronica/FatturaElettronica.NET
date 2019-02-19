using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Semplificata.Tests
{
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
