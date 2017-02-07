using FatturaElettronica.Common;

namespace FatturaElettronica.Validators
{
    public class TipoDocumentoDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return TipoDocumento.Codici;
            }
        }
    }
}
