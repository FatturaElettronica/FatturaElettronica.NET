using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiPagamento;
using FatturaElettronica.Tabelle;

namespace Tests
{
    [TestClass]
    public class DettaglioPagamentoValidator
        : BaseClass<DettaglioPagamento, FatturaElettronica.Validators.DettaglioPagamentoValidator>
    {
        [TestMethod]
        public void BeneficiarioIsOptional()
        {
            AssertOptional(x => x.Beneficiario);
        }
        [TestMethod]
        public void BeneficiarioMisuraMinMaxLength()
        {
            AssertMinMaxLength(x => x.Beneficiario, 1, 200);
        }
        [TestMethod]
        public void ModalitaPagamentoIsRequired()
        {
            AssertRequired(x => x.ModalitaPagamento);
        }
        [TestMethod]
        public void ModalitaPagamentoOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<ModalitaPagamento>(x => x.ModalitaPagamento);
        }
        [TestMethod]
        public void CodUfficioPostaleIsOptional()
        {
            AssertOptional(x => x.CodUfficioPostale);
        }
        [TestMethod]
        public void CodUfficioPostaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodUfficioPostale, 1, 20);
        }
        [TestMethod]
        public void CognomeQuietanzanteIsOptional()
        {
            AssertOptional(x => x.CognomeQuietanzante);
        }
        [TestMethod]
        public void CognomeQuietanzanteMinMaxLength()
        {
            AssertMinMaxLength(x => x.CognomeQuietanzante, 1, 60);
        }
        [TestMethod]
        public void NomeQuietanzanteIsOptional()
        {
            AssertOptional(x => x.NomeQuietanzante);
        }
        [TestMethod]
        public void NomeQuietanzanteMinMaxLength()
        {
            AssertMinMaxLength(x => x.NomeQuietanzante, 1, 60);
        }
        [TestMethod]
        public void CFQuietanzanteIsOptional()
        {
            AssertOptional(x => x.CFQuietanzante);
        }
        [TestMethod]
        public void CFQuietanzanteMinMaxLength()
        {
            AssertMinMaxLength(x => x.CFQuietanzante, 1, 16);
        }
        [TestMethod]
        public void TitoloQuietanzanteIsOptional()
        {
            AssertOptional(x => x.TitoloQuietanzante);
        }
        [TestMethod]
        public void TitoloQuietanzanteMinMaxLength()
        {
            AssertMinMaxLength(x => x.TitoloQuietanzante, 2, 10);
        }
        [TestMethod]
        public void IstitutoFinanziarioIsOptional()
        {
            AssertOptional(x => x.IstitutoFinanziario);
        }
        [TestMethod]
        public void IstitutoFinanziarioMinMaxLength()
        {
            AssertMinMaxLength(x => x.IstitutoFinanziario, 1, 80);
        }
        [TestMethod]
        public void IBANIsOptional()
        {
            AssertOptional(x => x.IBAN);
        }
        [TestMethod]
        public void IBANMinMaxLength()
        {
            AssertMinMaxLength(x => x.IBAN, 15, 34);
        }
        [TestMethod]
        public void ABIIsOptional()
        {
            AssertOptional(x => x.ABI);
        }
        [TestMethod]
        public void ABIMinMaxLength()
        {
            AssertLength(x => x.ABI, 5);
        }
        [TestMethod]
        public void CABIsOptional()
        {
            AssertOptional(x => x.CAB);
        }
        [TestMethod]
        public void CABMinMaxLength()
        {
            AssertLength(x => x.CAB, 5);
        }
        [TestMethod]
        public void BICIsOptional()
        {
            AssertOptional(x => x.BIC);
        }
        [TestMethod]
        public void BICMinMaxLength()
        {
            AssertMinMaxLength(x => x.BIC, 8, 11);
        }
        [TestMethod]
        public void CodicePagamentoIsOptional()
        {
            AssertOptional(x => x.CodicePagamento);
        }
        [TestMethod]
        public void CodicePagamentoMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodicePagamento, 1, 60);
        }
    }
}
