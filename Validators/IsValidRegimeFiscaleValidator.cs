namespace FatturaElettronica.Validators
{
    public class IsValidRegimeFiscaleValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.RegimeFiscale().Codici;
            }
        }
    }
}
