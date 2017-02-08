namespace FatturaElettronica.Validators
{
    public class IsSoggettoEmittenteValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.SoggettoEmittente().Codici;
            }
        }
    }
}
