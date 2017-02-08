namespace FatturaElettronica.Validators
{
    public class DivisaDomainValidator<T> : DomainValidator<T>
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
