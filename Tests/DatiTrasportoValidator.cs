using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DatiTrasportoValidator: BaseClass<DatiTrasporto, FatturaElettronica.Validators.DatiTrasportoValidator>
    {
        [TestMethod]
        public void DatiAnagraficiVettoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiAnagraficiVettore, typeof(FatturaElettronica.Validators.DatiAnagraficiVettoreValidator));
        }
        [TestMethod]
        public void MezzoTrasportoCanBeEmpty()
        {
            challenge.MezzoTrasporto = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.MezzoTrasporto, challenge);
            challenge.MezzoTrasporto = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.MezzoTrasporto, challenge);
        }
        [TestMethod]
        public void MezzoTrasportoMinMaxLength()
        {
            challenge.MezzoTrasporto = new string('x', 81);
            validator.ShouldHaveValidationErrorFor(x => x.MezzoTrasporto, challenge);
            challenge.MezzoTrasporto = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.MezzoTrasporto, challenge);
            challenge.MezzoTrasporto = new string('x', 80);
            validator.ShouldNotHaveValidationErrorFor(x => x.MezzoTrasporto, challenge);
        }
        [TestMethod]
        public void CausaleTrasportoCanBeEmpty()
        {
            challenge.CausaleTrasporto = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CausaleTrasporto, challenge);
            challenge.CausaleTrasporto = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.CausaleTrasporto, challenge);
        }
        [TestMethod]
        public void CausaleTrasportoMinMaxLength()
        {
            challenge.CausaleTrasporto = new string('x', 101);
            validator.ShouldHaveValidationErrorFor(x => x.CausaleTrasporto, challenge);
            challenge.CausaleTrasporto = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.CausaleTrasporto, challenge);
            challenge.CausaleTrasporto = new string('x', 100);
            validator.ShouldNotHaveValidationErrorFor(x => x.CausaleTrasporto, challenge);
        }
        [TestMethod]
        public void DescrizioneCanBeEmpty()
        {
            challenge.Descrizione = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Descrizione, challenge);
            challenge.Descrizione = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.Descrizione, challenge);
        }
        [TestMethod]
        public void DescrizioneMinMaxLength()
        {
            challenge.Descrizione = new string('x', 101);
            validator.ShouldHaveValidationErrorFor(x => x.Descrizione, challenge);
            challenge.Descrizione = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.Descrizione, challenge);
            challenge.Descrizione = new string('x', 100);
            validator.ShouldNotHaveValidationErrorFor(x => x.Descrizione, challenge);
        }
        [TestMethod]
        public void UnitaMisuraPesoCanBeEmpty()
        {
            challenge.UnitaMisuraPeso = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.UnitaMisuraPeso, challenge);
            challenge.UnitaMisuraPeso = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.UnitaMisuraPeso, challenge);
        }
        [TestMethod]
        public void UnitaMisuraPesoMinMaxLength()
        {
            challenge.UnitaMisuraPeso = new string('x', 11);
            validator.ShouldHaveValidationErrorFor(x => x.UnitaMisuraPeso, challenge);
            challenge.UnitaMisuraPeso = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.UnitaMisuraPeso, challenge);
            challenge.UnitaMisuraPeso = new string('x', 10);
            validator.ShouldNotHaveValidationErrorFor(x => x.UnitaMisuraPeso, challenge);
        }
        [TestMethod]
        public void TipoResaCanBeEmpty()
        {
            challenge.TipoResa = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoResa, challenge);
            challenge.TipoResa = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoResa, challenge);
        }
        [TestMethod]
        public void TipoResaCanOnlyAcceptValidValues()
        {
            challenge.TipoResa = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.TipoResa, challenge);
            challenge.TipoResa = "EXW";
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoResa, challenge);
            challenge.TipoResa = "DDP";
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoResa, challenge);
        }
        [TestMethod]
        public void IndirizzoResaHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.IndirizzoResa, typeof(FatturaElettronica.Validators.IndirizzoResaValidator));
        }
    }
}
