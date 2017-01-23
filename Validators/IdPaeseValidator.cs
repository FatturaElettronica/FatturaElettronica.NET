using BusinessObjects;

namespace FatturaElettronica.Validators
{
    public class IdPaeseDomainValidator<T> : DomainValidator<T>
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
