using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    public class FPrezzoTotaleValidator : DelegateValidator
    {
        public FPrezzoTotaleValidator(string propertyName, string description, SimpleValidatorDelegate ruleDelegate) : base(propertyName, description, ruleDelegate)
        {
        }
    }
}
