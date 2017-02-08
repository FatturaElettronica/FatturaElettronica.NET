namespace FatturaElettronica.Validators
{
    public class RegimeFiscaleDomainValidator<T> : DomainValidator<T>
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
