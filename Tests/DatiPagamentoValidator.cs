using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiPagamento;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DatiPagamentoValidator: BaseClass<DatiPagamento, FatturaElettronica.Validators.DatiPagamentoValidator>
    {
        [TestMethod]
        public void CondizioniPagamentoCannotBeEmpty()
        {
            challenge.CondizioniPagamento = null;
            validator.ShouldHaveValidationErrorFor(x => x.CondizioniPagamento, challenge);
            challenge.CondizioniPagamento = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.CondizioniPagamento, challenge);
        }
        [TestMethod]
        public void CondizioniPagamentoCanOnlyAcceptDomainValues()
        {
            challenge.CondizioniPagamento = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.CondizioniPagamento, challenge);
            challenge.CondizioniPagamento = "TP01";
            validator.ShouldNotHaveValidationErrorFor(x => x.CondizioniPagamento, challenge);
            challenge.CondizioniPagamento = "TP03";
            validator.ShouldNotHaveValidationErrorFor(x => x.CondizioniPagamento, challenge);
        }
        [TestMethod]
        public void DettaglioPagamentoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DettaglioPagamento, typeof(FatturaElettronica.Validators.DettaglioPagamentoValidator));
        }
        [TestMethod]
        public void DettaglioPagamentoCollectionCannotBeEmpty()
        {
            var r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DettaglioPagamento"));

            challenge.DettaglioPagamento.Add(new DettaglioPagamento());
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DettaglioPagamento"));
        }
    }
}
