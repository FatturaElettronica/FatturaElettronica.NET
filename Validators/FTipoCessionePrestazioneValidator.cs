using BusinessObjects.Validators;

namespace FatturaElettronicaPA.Validators {
    /// <summary>
    /// Validates Body.DatiBeniServizi.TipoCessionePrestazione
    /// </summary>
    public class FTipoCessionePrestazioneValidator : DomainValidator {

        private const string BrokenDescription = "Valori ammessi: [SC] sconto, [PR] premio, [AB] abbuono, [AC] spesa accessoria.";

        /// <summary>
        /// Validates Body.DatiBeniServizi.TipoCessionePrestazione
        /// </summary>
        public FTipoCessionePrestazioneValidator() : this(null, BrokenDescription) { }
        public FTipoCessionePrestazioneValidator(string propertyName) : this(propertyName, BrokenDescription) { }
        public FTipoCessionePrestazioneValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = new[] {"SC", "PR", "AB", "AC" };
        }
    }
}
