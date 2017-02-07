using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiRitenutaValidator: BaseClass<DatiRitenuta, FatturaElettronica.Validators.DatiRitenutaValidator>
    {
        [TestMethod]
        public void TipoRitenutaCannotBeEmpty()
        {
            challenge.TipoRitenuta = null;
            validator.ShouldHaveValidationErrorFor(x => x.TipoRitenuta, challenge);
            challenge.TipoRitenuta = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.TipoRitenuta, challenge);
        }
        [TestMethod]
        public void TipoRitenutaCanOnlyAcceptDomainValues()
        {
            challenge.TipoRitenuta = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.TipoRitenuta, challenge);
            challenge.TipoRitenuta = "RT01";
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoRitenuta, challenge);
            challenge.TipoRitenuta = "RT02";
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoRitenuta, challenge);
        }
        [TestMethod]
        public void ImportoPagamentoCannotBeNull()
        {
            challenge.ImportoRitenuta = null;
            validator.ShouldHaveValidationErrorFor(x => x.ImportoRitenuta, challenge);
            challenge.ImportoRitenuta = 0;
            validator.ShouldNotHaveValidationErrorFor(x => x.ImportoRitenuta, challenge);
        }
        [TestMethod]
        public void AliquotaRitenutaCannotBeNull()
        {
            challenge.AliquotaRitenuta = null;
            validator.ShouldHaveValidationErrorFor(x => x.AliquotaRitenuta, challenge);
            challenge.AliquotaRitenuta = 0;
            validator.ShouldNotHaveValidationErrorFor(x => x.AliquotaRitenuta, challenge);
        }
        [TestMethod]
        public void CausalePagamentoCannotBeEmpty()
        {
            challenge.CausalePagamento = null;
            validator.ShouldHaveValidationErrorFor(x => x.CausalePagamento, challenge);
            challenge.CausalePagamento = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.CausalePagamento, challenge);
        }
        [TestMethod]
        public void CausalePagamentoCanOnlyAcceptDomainValues()
        {
            challenge.CausalePagamento = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.CausalePagamento, challenge);
            challenge.CausalePagamento = "A";
            validator.ShouldNotHaveValidationErrorFor(x => x.CausalePagamento, challenge);
            challenge.CausalePagamento = "Z";
            validator.ShouldNotHaveValidationErrorFor(x => x.CausalePagamento, challenge);
        }
    }
}
