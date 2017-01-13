using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    public class FXorRequiredValidator : XorRequiredValidator {
        public FXorRequiredValidator(string[] properties) : base(properties, "Valore necessario."){ }
    }
}
