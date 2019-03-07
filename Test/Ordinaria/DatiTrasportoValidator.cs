using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Ordinaria.Tests
{
    [TestClass]
    public class DatiTrasportoValidator
        : BaseClass<DatiTrasporto, FatturaElettronica.Validators.DatiTrasportoValidator>
    {
        [TestMethod]
        public void DatiAnagraficiVettoreHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(
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
        public void MezzoTrasportoMinMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.MezzoTrasporto);
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
        public void CausaleTrasportoMinMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.CausaleTrasporto);
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
        public void DescrizioneMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.Descrizione);
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
        public void UnitaMisuraPesoMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.UnitaMisuraPeso);
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
            validator.ShouldHaveDelegatePropertyChildValidator(x => x.IndirizzoResa, typeof(FatturaElettronica.Validators.IndirizzoResaValidator));
        }
        [TestMethod]
        public void PesoNettoMaxValue()
        {
            validator.ShouldHaveValidationErrorFor(x => x.PesoNetto, 10000m);
            validator.ShouldNotHaveValidationErrorFor(x => x.PesoNetto, 9999.99m);
        }
        [TestMethod]
        public void PesoLordoMaxValue()
        {
            validator.ShouldHaveValidationErrorFor(x => x.PesoLordo, 10000m);
            validator.ShouldNotHaveValidationErrorFor(x => x.PesoLordo, 9999.99m);
        }
    }
}
