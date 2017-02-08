using BusinessObjects;

namespace FatturaElettronica.Validators
{
    public class IsValidIdPaeseValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return Country.TwoLetterCodes;
            }
        }
    }
}
