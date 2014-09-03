using BusinessObjects.Validators;

namespace FatturaElettronicaPA.Validators
{
    public class FXorRequiredValidator : XorRequiredValidator {
        public FXorRequiredValidator(string[] properties) : base(properties, "Valore necessario."){ }
    }
}
