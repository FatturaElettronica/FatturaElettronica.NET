using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiPagamento;

namespace Tests
{
    [TestClass]
    public class DettaglioPagamentoValidator: BaseClass<DettaglioPagamento, FatturaElettronica.Validators.DettaglioPagamentoValidator>
    {
        [TestMethod]
        public void BeneficiarioCanBeEmpty()
        {
            challenge.Beneficiario = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Beneficiario, challenge);
            challenge.Beneficiario = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.Beneficiario, challenge);
        }
        [TestMethod]
        public void BeneficiarioMisuraMinMaxLength()
        {
            challenge.Beneficiario = new string('x', 201);
            validator.ShouldHaveValidationErrorFor(x => x.Beneficiario, challenge);
            challenge.Beneficiario = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.Beneficiario, challenge);
            challenge.Beneficiario = new string('x', 200);
            validator.ShouldNotHaveValidationErrorFor(x => x.Beneficiario, challenge);
        }
        [TestMethod]
        public void ModalitaPagamentoCannotBeEmpty()
        {
            challenge.ModalitaPagamento = null;
            validator.ShouldHaveValidationErrorFor(x => x.ModalitaPagamento, challenge);
            challenge.ModalitaPagamento = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.ModalitaPagamento, challenge);
        }
        [TestMethod]
        public void ModalitaPagamentoCanOnlyAcceptDomainValues()
        {
            challenge.ModalitaPagamento = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.ModalitaPagamento, challenge);
            challenge.ModalitaPagamento = "MP01";
            validator.ShouldNotHaveValidationErrorFor(x => x.ModalitaPagamento, challenge);
            challenge.ModalitaPagamento = "MP22";
            validator.ShouldNotHaveValidationErrorFor(x => x.ModalitaPagamento, challenge);
        }
        [TestMethod]
        public void CodUfficioPostaleCanBeEmpty()
        {
            challenge.CodUfficioPostale = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodUfficioPostale, challenge);
            challenge.CodUfficioPostale = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodUfficioPostale, challenge);
        }
        [TestMethod]
        public void CodUfficioPostaleMinMaxLength()
        {
            challenge.CodUfficioPostale = new string('x', 21);
            validator.ShouldHaveValidationErrorFor(x => x.CodUfficioPostale, challenge);
            challenge.CodUfficioPostale = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodUfficioPostale, challenge);
            challenge.CodUfficioPostale = new string('x', 20);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodUfficioPostale, challenge);
        }
        [TestMethod]
        public void CognomeQuietanzanteCanBeEmpty()
        {
            challenge.CognomeQuietanzante = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CognomeQuietanzante, challenge);
            challenge.CognomeQuietanzante = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.CognomeQuietanzante, challenge);
        }
        [TestMethod]
        public void CognomeQuietanzanteMinMaxLength()
        {
            challenge.CognomeQuietanzante = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.CognomeQuietanzante, challenge);
            challenge.CognomeQuietanzante = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.CognomeQuietanzante, challenge);
            challenge.CognomeQuietanzante = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.CognomeQuietanzante, challenge);
        }
        [TestMethod]
        public void NomeQuietanzanteCanBeEmpty()
        {
            challenge.NomeQuietanzante = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.NomeQuietanzante, challenge);
            challenge.NomeQuietanzante = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.NomeQuietanzante, challenge);
        }
        [TestMethod]
        public void NomeQuietanzanteMinMaxLength()
        {
            challenge.NomeQuietanzante = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.NomeQuietanzante, challenge);
            challenge.NomeQuietanzante = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.NomeQuietanzante, challenge);
            challenge.NomeQuietanzante = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.NomeQuietanzante, challenge);
        }
        [TestMethod]
        public void CFQuietanzanteCanBeEmpty()
        {
            challenge.CFQuietanzante = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CFQuietanzante, challenge);
            challenge.CFQuietanzante = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.CFQuietanzante, challenge);
        }
        [TestMethod]
        public void CFQuietanzanteMinMaxLength()
        {
            challenge.CFQuietanzante = new string('x', 17);
            validator.ShouldHaveValidationErrorFor(x => x.CFQuietanzante, challenge);
            challenge.CFQuietanzante = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.CFQuietanzante, challenge);
            challenge.CFQuietanzante = new string('x', 16);
            validator.ShouldNotHaveValidationErrorFor(x => x.CFQuietanzante, challenge);
        }
        [TestMethod]
        public void TitoloQuietanzanteCanBeEmpty()
        {
            challenge.TitoloQuietanzante = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.TitoloQuietanzante, challenge);
            challenge.TitoloQuietanzante = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.TitoloQuietanzante, challenge);
        }
        [TestMethod]
        public void TitoloQuietanzanteMinMaxLength()
        {
            challenge.TitoloQuietanzante = new string('x', 11);
            validator.ShouldHaveValidationErrorFor(x => x.TitoloQuietanzante, challenge);
            challenge.TitoloQuietanzante = new string('x', 2);
            validator.ShouldNotHaveValidationErrorFor(x => x.TitoloQuietanzante, challenge);
            challenge.TitoloQuietanzante = new string('x', 10);
            validator.ShouldNotHaveValidationErrorFor(x => x.TitoloQuietanzante, challenge);
        }
        [TestMethod]
        public void IstitutoFinanziarioCanBeEmpty()
        {
            challenge.IstitutoFinanziario = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.IstitutoFinanziario, challenge);
            challenge.IstitutoFinanziario = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.IstitutoFinanziario, challenge);
        }
        [TestMethod]
        public void IstitutoFinanziarioMinMaxLength()
        {
            challenge.IstitutoFinanziario = new string('x', 81);
            validator.ShouldHaveValidationErrorFor(x => x.IstitutoFinanziario, challenge);
            challenge.IstitutoFinanziario = new string('x', 2);
            validator.ShouldNotHaveValidationErrorFor(x => x.IstitutoFinanziario, challenge);
            challenge.IstitutoFinanziario = new string('x', 80);
            validator.ShouldNotHaveValidationErrorFor(x => x.IstitutoFinanziario, challenge);
        }
        [TestMethod]
        public void IBANCanBeEmpty()
        {
            challenge.IBAN = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.IBAN, challenge);
            challenge.IBAN = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.IBAN, challenge);
        }
        [TestMethod]
        public void IBANMinMaxLength()
        {
            challenge.IBAN = new string('x', 14);
            validator.ShouldHaveValidationErrorFor(x => x.IBAN, challenge);
            challenge.IBAN = new string('x', 35);
            validator.ShouldHaveValidationErrorFor(x => x.IBAN, challenge);
            challenge.IBAN = new string('x', 15);
            validator.ShouldNotHaveValidationErrorFor(x => x.IBAN, challenge);
            challenge.IBAN = new string('x', 34);
            validator.ShouldNotHaveValidationErrorFor(x => x.IBAN, challenge);
        }
        [TestMethod]
        public void ABICanBeEmpty()
        {
            challenge.ABI = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.ABI, challenge);
            challenge.ABI = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.ABI, challenge);
        }
        [TestMethod]
        public void ABIMinMaxLength()
        {
            challenge.ABI = new string('x', 4);
            validator.ShouldHaveValidationErrorFor(x => x.ABI, challenge);
            challenge.ABI = new string('x', 6);
            validator.ShouldHaveValidationErrorFor(x => x.ABI, challenge);
            challenge.ABI = new string('x', 5);
            validator.ShouldNotHaveValidationErrorFor(x => x.ABI, challenge);
        }
        [TestMethod]
        public void CABCanBeEmpty()
        {
            challenge.CAB = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CAB, challenge);
            challenge.CAB = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.CAB, challenge);
        }
        [TestMethod]
        public void CABMinMaxLength()
        {
            challenge.CAB = new string('x', 4);
            validator.ShouldHaveValidationErrorFor(x => x.CAB, challenge);
            challenge.CAB = new string('x', 6);
            validator.ShouldHaveValidationErrorFor(x => x.CAB, challenge);
            challenge.CAB = new string('x', 5);
            validator.ShouldNotHaveValidationErrorFor(x => x.CAB, challenge);
        }
        [TestMethod]
        public void BICCanBeEmpty()
        {
            challenge.BIC = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.BIC, challenge);
            challenge.BIC = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.BIC, challenge);
        }
        [TestMethod]
        public void BICMinMaxLength()
        {
            challenge.BIC = new string('x', 7);
            validator.ShouldHaveValidationErrorFor(x => x.BIC, challenge);
            challenge.BIC = new string('x', 12);
            validator.ShouldHaveValidationErrorFor(x => x.BIC, challenge);
            challenge.BIC = new string('x', 8);
            validator.ShouldNotHaveValidationErrorFor(x => x.BIC, challenge);
            challenge.BIC = new string('x', 11);
            validator.ShouldNotHaveValidationErrorFor(x => x.BIC, challenge);
        }
        [TestMethod]
        public void CodicePagamentoCanBeEmpty()
        {
            challenge.CodicePagamento = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodicePagamento, challenge);
            challenge.CodicePagamento = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodicePagamento, challenge);
        }
        [TestMethod]
        public void CodicePagamentoMinMaxLength()
        {
            challenge.CodicePagamento = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.CodicePagamento, challenge);
            challenge.CodicePagamento = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodicePagamento, challenge);
            challenge.CodicePagamento = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodicePagamento, challenge);
        }
    }
}
