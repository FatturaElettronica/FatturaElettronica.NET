namespace FatturaElettronica.Validators
{
    public class IsValidProvinciaValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.Provincia().Codici;
            }
        }
    }
}
