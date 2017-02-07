namespace FatturaElettronica.Validators
{
    public class TipoDocumentoDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return Tabelle.TipoDocumento.Codici;
            }
        }
    }
}
