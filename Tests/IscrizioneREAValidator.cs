using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class IscrizioneREAValidator : BaseClass<IscrizioneREA, FatturaElettronica.Validators.IscrizioneREAValidator>
    {
        [TestMethod]
        public void UfficioCannotBeEmpty()
        {
            challenge.Ufficio = null;
            validator.ShouldHaveValidationErrorFor(x => x.Ufficio, challenge);
            challenge.Ufficio = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Ufficio, challenge);
        }
        [TestMethod]
        public void UfficioCanOnlyAcceptDomainValues()
        {
            challenge.Ufficio = "XX";
            validator.ShouldHaveValidationErrorFor(x => x.Ufficio, challenge);
            challenge.Ufficio = "RA";
            validator.ShouldNotHaveValidationErrorFor(x => x.Ufficio, challenge);
        }
        [TestMethod]
        public void NumeroREACannotBeEmpty()
        {
            challenge.NumeroREA = null;
            validator.ShouldHaveValidationErrorFor(x => x.NumeroREA, challenge);
            challenge.NumeroREA = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.NumeroREA, challenge);
        }
        [TestMethod]
        public void NumeroREAMinMaxLength()
        {
            challenge.NumeroREA = new string('x', 21);
            validator.ShouldHaveValidationErrorFor(x => x.NumeroREA, challenge);
            challenge.NumeroREA = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroREA, challenge);
            challenge.NumeroREA = new string('x', 20);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroREA, challenge);
        }
        [TestMethod]
        public void UfficioCanBeEmpty()
        {
            challenge.SocioUnico = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.SocioUnico, challenge);
            challenge.SocioUnico = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.SocioUnico, challenge);
        }
        [TestMethod]
        public void SocioUnicoCanOnlyAcceptDomainValues()
        {
            challenge.SocioUnico = "XX";
            validator.ShouldHaveValidationErrorFor(x => x.SocioUnico, challenge);
            challenge.SocioUnico = "SU";
            validator.ShouldNotHaveValidationErrorFor(x => x.SocioUnico, challenge);
            challenge.SocioUnico = "SM";
            validator.ShouldNotHaveValidationErrorFor(x => x.SocioUnico, challenge);
        }
        [TestMethod]
        public void StatoLiquidazioneCannotBeEmpty()
        {
            challenge.StatoLiquidazione = null;
            validator.ShouldHaveValidationErrorFor(x => x.StatoLiquidazione, challenge);
            challenge.StatoLiquidazione = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.StatoLiquidazione, challenge);
        }
        [TestMethod]
        public void StatoLiquidazioneCanOnlyAcceptDomainValues()
        {
            challenge.StatoLiquidazione = "XX";
            validator.ShouldHaveValidationErrorFor(x => x.StatoLiquidazione, challenge);
            challenge.StatoLiquidazione = "LS";
            validator.ShouldNotHaveValidationErrorFor(x => x.StatoLiquidazione, challenge);
            challenge.StatoLiquidazione = "LN";
            validator.ShouldNotHaveValidationErrorFor(x => x.StatoLiquidazione, challenge);
        }
    }
}
