using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiPagamento;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiPagamentoValidator
        : BaseClass<DatiPagamento, FatturaElettronica.Validators.DatiPagamentoValidator>
    {
        [TestMethod]
        public void CondizioniPagamentoIsRequired()
        {
            AssertRequired(x => x.CondizioniPagamento);
        }

        [TestMethod]
        public void CondizioniPagamentoOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<CondizioniPagamento>(x => x.CondizioniPagamento);
        }

        [TestMethod]
        public void DettaglioPagamentoHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.DettaglioPagamento, typeof(FatturaElettronica.Validators.DettaglioPagamentoValidator));
        }

        [TestMethod]
        public void DettaglioPagamentoCollectionCannotBeEmpty()
        {
            AssertCollectionCannotBeEmpty(x => x.DettaglioPagamento);
        }
    }
}