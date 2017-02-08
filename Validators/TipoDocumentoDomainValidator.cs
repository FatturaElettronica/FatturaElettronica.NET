namespace FatturaElettronica.Validators
{
    public class TipoDocumentoDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.TipoDocumento().Codici;
            }
        }
    }
}
