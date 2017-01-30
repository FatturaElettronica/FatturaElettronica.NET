using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Common;

namespace Tests
{
    [TestClass]
    public class AnagraficaValidator : DenominazioneNomeCognomeValidator<Anagrafica, FatturaElettronica.Validators.AnagraficaValidator>
    {
        [TestMethod]
        public void TitoloMinMaxLength()
        {
            challenge.Titolo = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Titolo, challenge);
            challenge.Titolo = new string('x', 1);
            validator.ShouldHaveValidationErrorFor(x => x.Titolo, challenge);
            challenge.Titolo = new string('x', 11);
            validator.ShouldHaveValidationErrorFor(x => x.Titolo, challenge);
            challenge.Titolo = new string('x', 2);
            validator.ShouldNotHaveValidationErrorFor(x => x.Titolo, challenge);
            challenge.Titolo = new string('x', 10);
            validator.ShouldNotHaveValidationErrorFor(x => x.Titolo, challenge);
        }
        [TestMethod]
        public void CodEORIMinMaxLength()
        {
            challenge.CodEORI = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodEORI, challenge);
            challenge.CodEORI = new string('x', 12);
            validator.ShouldHaveValidationErrorFor(x => x.CodEORI, challenge);
            challenge.CodEORI = new string('x', 18);
            validator.ShouldHaveValidationErrorFor(x => x.CodEORI, challenge);
            challenge.CodEORI = new string('x', 13);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodEORI, challenge);
            challenge.CodEORI = new string('x', 17);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodEORI, challenge);
        }
    }
}
