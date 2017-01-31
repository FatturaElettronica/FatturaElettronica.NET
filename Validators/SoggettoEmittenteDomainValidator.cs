using FatturaElettronica.Common;

namespace FatturaElettronica.Validators
{
    public class SoggettoEmittenteDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return SoggettoEmittente.Codici;
            }
        }
    }
}
