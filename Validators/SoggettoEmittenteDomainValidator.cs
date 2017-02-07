namespace FatturaElettronica.Validators
{
    public class SoggettoEmittenteDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return Tabelle.SoggettoEmittente.Codici;
            }
        }
    }
}
