namespace FatturaElettronica.Validators
{
    public class ProvinciaDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return Common.Provincia.Sigle;
            }
        }
    }
}
