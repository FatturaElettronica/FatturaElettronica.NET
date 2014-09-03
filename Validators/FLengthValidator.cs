using BusinessObjects.Validators;

namespace FatturaElettronicaPA.Validators {
    public class FLengthValidator : LengthValidator {

        /// <summary>
        /// Constructor.
        /// </summary>
        public FLengthValidator(int length) : this(null, length) { }
        public FLengthValidator(int min, int max) : this(null,  min, max) { }
        public FLengthValidator(string propertyName, int length) : base(propertyName, string.Format("La lunghezza deve essere {0}.", length), length) { }
        public FLengthValidator(string propertyName, int min, int max) : base(propertyName, string.Format("La lunghezza deve essere tra {0} e {1}.", min, max), min, max) { }
    }
}
