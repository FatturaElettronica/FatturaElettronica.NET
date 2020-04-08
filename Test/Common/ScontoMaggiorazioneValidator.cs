using FatturaElettronica.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Common
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
            // Necessario per non incappare nell'errore 00437.
            Challenge.Importo = 1;

            AssertOnlyAcceptsTableValues<FatturaElettronica.Tabelle.ScontoMaggiorazione>(x => x.Tipo);
        }

        [TestMethod]
        public void TipoValidateAgainstError00437()
        {
            Challenge.Tipo = "SC";

            Challenge.Importo = null;
            Challenge.Percentuale = null;
            Validator.ShouldHaveValidationErrorFor(x => x.Tipo, Challenge).WithErrorCode("00437");

            Challenge.Importo = null;
            Challenge.Percentuale = 0;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Tipo, Challenge);
            Challenge.Importo = 0;
            Challenge.Percentuale = null;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Tipo, Challenge);
        }
    }
}