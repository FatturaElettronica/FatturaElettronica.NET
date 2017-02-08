using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    /// <summary>
    /// Validates that a property conforms to ISO 3166-1 alpha 2 codes.
    /// </summary>
    public class FProvinciaValidator : DomainValidator
    {
        private const string BrokenDescription = "Deve essere una sigla di provincia italiana ([MI], [FI], [..])";

        /// <summary>
        /// Constructor.
        /// </summary>
        public FProvinciaValidator() : this(null, BrokenDescription) { }
        public FProvinciaValidator(string propertyName) : this(propertyName, BrokenDescription) { }
        public FProvinciaValidator(string propertyName, string description) : base(propertyName, description) {
            Domain = new Tabelle.Provincia().Codici;
        }

    }
}
