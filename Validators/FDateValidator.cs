using BusinessObjects.Validators;

namespace FatturaElettronicaPA.Validators {
    // TODO remove this class as it is not needed anymore.
    public class FDateValidator : RegexValidator {

        private const string BrokenDescription = "Deve essere nel formato YYYY-MM-DD.";
        /// <summary>
        /// Constructor.
        /// </summary>
        public FDateValidator() : base(null, BrokenDescription) { }
        public FDateValidator(string propertyName) : base(propertyName, BrokenDescription) {
            Regex = @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$";
        }
    }
}
