using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace Tests
{
    [TestClass]
    public class DatiTrasportoValidator
        : BaseClass<DatiTrasporto, FatturaElettronica.Validators.DatiTrasportoValidator>
    {
        [TestMethod]
        public void DatiAnagraficiVettoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiAnagraficiVettore, typeof(FatturaElettronica.Validators.DatiAnagraficiVettoreValidator));
        }
        [TestMethod]
        public void MezzoTrasportoIsOptional()
        {
            AssertOptional(x => x.MezzoTrasporto);
        }
        [TestMethod]
        public void MezzoTrasportoMinMaxLength()
        {
            AssertMinMaxLength(x => x.MezzoTrasporto, 1, 80);
        }
        [TestMethod]
        public void CausaleTrasportoIsOptional()
        {
            AssertOptional(x => x.CausaleTrasporto);
        }
        [TestMethod]
        public void CausaleTrasportoMinMaxLength()
        {
            AssertMinMaxLength(x => x.CausaleTrasporto, 1, 100);
        }
        [TestMethod]
        public void DescrizioneIsOptional()
        {
            AssertOptional(x => x.Descrizione);
        }
        [TestMethod]
        public void DescrizioneMinMaxLength()
        {
            AssertMinMaxLength(x => x.Descrizione, 1, 100);
        }
        [TestMethod]
        public void UnitaMisuraPesoIsOptional()
        {
            AssertOptional(x => x.UnitaMisuraPeso);
        }
        [TestMethod]
        public void UnitaMisuraPesoMinMaxLength()
        {
            AssertMinMaxLength(x => x.UnitaMisuraPeso, 1, 10);
        }
        [TestMethod]
        public void TipoResaIsOptional()
        {
            AssertOptional(x => x.TipoResa);
        }
        [TestMethod]
        public void TipoResaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<TipoResa>(x => x.TipoResa);
        }
        [TestMethod]
        public void IndirizzoResaHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.IndirizzoResa, typeof(FatturaElettronica.Validators.IndirizzoResaValidator));
        }
    }
}
