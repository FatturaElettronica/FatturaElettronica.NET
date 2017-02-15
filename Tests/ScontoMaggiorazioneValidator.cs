using FatturaElettronica.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ScontoMaggiorazioneValidator 
        : BaseClass<ScontoMaggiorazione, FatturaElettronica.Validators.ScontoMaggiorazioneValidator>
    {

        [TestMethod]
        public void TipoIsRequired()
        {
            AssertRequired(x => x.Tipo);
        }
        [TestMethod]
        public void TipoOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<FatturaElettronica.Tabelle.ScontoMaggiorazione>(x => x.Tipo);
        }
        [TestMethod]
        public void ImportoMustHaveValueUnlessPercentualeDoes()
        {
            challenge.Importo = null;
            validator.ShouldHaveValidationErrorFor(x => x.Importo, challenge);
            validator.ShouldHaveValidationErrorFor(x => x.Percentuale, challenge);
            challenge.Importo = 0;
            validator.ShouldHaveValidationErrorFor(x => x.Importo, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Percentuale, challenge);
            challenge.Importo = 1;
            validator.ShouldNotHaveValidationErrorFor(x => x.Importo, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Percentuale, challenge);
        }
        [TestMethod]
        public void PercentualeMustHaveValueUnlessPercentualeDoes()
        {
            challenge.Percentuale = null;
            validator.ShouldHaveValidationErrorFor(x => x.Percentuale, challenge);
            validator.ShouldHaveValidationErrorFor(x => x.Importo, challenge);
            challenge.Percentuale = 0;
            validator.ShouldHaveValidationErrorFor(x => x.Percentuale, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Importo, challenge);
            challenge.Percentuale = 1;
            validator.ShouldNotHaveValidationErrorFor(x => x.Percentuale, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Importo, challenge);
        }
    }
}
