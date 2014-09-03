using BusinessObjects.Validators;

namespace FatturaElettronicaPA.Validators {
    public class FRequiredValidator : RequiredValidator {

        /// <summary>
        /// Constructor.
        /// </summary>
        public FRequiredValidator() : base(null, "Valore necessario.") { }
        public FRequiredValidator(string propertyName) : base(propertyName, "Valore necessario.") { }
    }
}
