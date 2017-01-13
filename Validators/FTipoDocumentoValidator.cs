using BusinessObjects.Validators;

namespace FatturaElettronica.Validators {
    /// <summary>
    /// Validates that a property conforms to ISO 3166-1 alpha 2 codes.
    /// </summary>
    public class FTipoDocumentoValidator : DomainValidator {

        private const string BrokenDescription = "Valori ammessi ([TD01], [TD02], [..], [TD06])";

        /// <summary>
        /// Constructor.
        /// </summary>
        public FTipoDocumentoValidator() : this(null, BrokenDescription) { }
        public FTipoDocumentoValidator(string propertyName) : this(propertyName, BrokenDescription) { }
        public FTipoDocumentoValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = new[] {"TD01", "TD02", "TD03", "TD04", " TD05", "TD06"};
        }
    }
}
