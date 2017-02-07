using FatturaElettronica.Common;

namespace FatturaElettronica.Validators
{
    public class DivisaDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return Divisa.Sigle;
            }
        }
    }
}
