using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    /// <summary>
    /// Validates FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Tipo
    /// </summary>
    public class FTipoScontoMaggiorazioneValidator : DomainValidator
    {

        /// <summary>
        /// Validates FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Tipo
        /// </summary>
        public FTipoScontoMaggiorazioneValidator() : this(null, "Valori ammessi: [SC], [MG]") { }
        public FTipoScontoMaggiorazioneValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = new[] { "SC", "MG" };
        }
    }
}
