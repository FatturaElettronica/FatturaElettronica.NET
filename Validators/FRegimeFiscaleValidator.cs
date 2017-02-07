using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    /// <summary>
    /// Validates that a property conforms to ISO 3166-1 alpha 2 codes.
    /// </summary>
    public class FRegimeFiscaleValidator : DomainValidator
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public FRegimeFiscaleValidator()
            : this(null, "Deve essere un regime fiscale valido ([RF01], [RF02], [..])")
        {
        }

        public FRegimeFiscaleValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = Tabelle.RegimeFiscale.Codici;
        }
    }
}
