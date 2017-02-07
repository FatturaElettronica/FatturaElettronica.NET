namespace FatturaElettronica.Validators
{
    public class ProvinciaDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return Tabelle.Provincia.Sigle;
            }
        }
    }
}
