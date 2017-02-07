namespace FatturaElettronica.Validators
{
    public class DivisaDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return Tabelle.Divisa.Sigle;
            }
        }
    }
}
