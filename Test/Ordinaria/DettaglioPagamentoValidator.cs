﻿using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiPagamento;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ordinaria.Tests
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
        public void BeneficiarioMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.Beneficiario);
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
        public void CodUfficioPostaleMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.CodUfficioPostale);
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
        public void CognomeQuietanzanteMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.CognomeQuietanzante);
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
        public void NomeQuietanzanteMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.NomeQuietanzante);
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
        public void TitoloQuietanzanteMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.TitoloQuietanzante);
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
        public void IstitutoFinanziarioMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.IstitutoFinanziario);
        }
        [TestMethod]
        public void IBANIsOptional()
        {
            AssertOptional(x => x.IBAN);
        }
        [TestMethod]
        public void IBANMustBeValid()
        {
            challenge.IBAN = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.IBAN, challenge);
            challenge.IBAN = "IBAN IT17 X060 5502 1000 0000 1234 567";
            validator.ShouldHaveValidationErrorFor(x => x.IBAN, challenge);
            challenge.IBAN = "IBANIT17X0605502100000001234567";
            validator.ShouldNotHaveValidationErrorFor(x => x.IBAN, challenge);
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
        [TestMethod]
        public void CodicePagamentoMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.CodicePagamento);
        }
    }
}
