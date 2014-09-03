using BusinessObjects.Validators;

namespace FatturaElettronicaPA.Validators {
    /// <summary>
    /// Validates that a property conforms to ISO 3166-1 alpha 2 codes.
    /// </summary>
    public class FCountryValidator : CountryValidator {

        /// <summary>
        /// Constructor.
        /// </summary>
        public FCountryValidator(string propertyName) : base(propertyName, "Deve essere un valore ISO 3166-1 alpha 2 ([IT], [UK], [...])") { }
        public FCountryValidator() : base(null, "Deve essere un valore ISO 3166-1 alpha 2 ([IT], [UK], [...])") { }
    }
}
