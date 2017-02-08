using BusinessObjects;

namespace FatturaElettronica.Validators
{
    public class IsValidNaturaValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.Natura().Codici;
            }
        }
    }
}
