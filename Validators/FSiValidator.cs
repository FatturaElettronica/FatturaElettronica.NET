using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    /// <summary>
    /// Validates that a property conforms to FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Art73 validation rule.
    /// </summary>
    public class FSiValidator : DomainValidator
    {
        private const string BrokenDescription = "Valore ammesso: [SI]";

        /// <summary>
        /// Constructor.
        /// </summary>
        public FSiValidator() : this(null, BrokenDescription) { }
        public FSiValidator(string propertyName) : this(propertyName, BrokenDescription) { }
        public FSiValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = new[] {"SI"};
        }

    }
}
