using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    /// <summary>
    /// Validates that a property conforms to FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Art73 validation rule.
    /// </summary>
    public class FTipoRitenutaValidator : DomainValidator
    {
        private const string BrokenDescription = "Valori ammessi: [RT01] per persone fisiche; [RT02] per persone giuridiche.";

        /// <summary>
        /// Constructor.
        /// </summary>
        public FTipoRitenutaValidator() : this(null, BrokenDescription) { }
        public FTipoRitenutaValidator(string propertyName) : this(propertyName, BrokenDescription) { }
        public FTipoRitenutaValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = new[] {"RT01", "RT02"};
        }

    }
}
