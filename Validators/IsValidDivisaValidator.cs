namespace FatturaElettronica.Validators
{
    public class IsValidDivisaValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.Divisa().Codici;
            }
        }
    }
}
