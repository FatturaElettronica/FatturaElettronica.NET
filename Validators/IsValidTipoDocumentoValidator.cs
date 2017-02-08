namespace FatturaElettronica.Validators
{
    public class IsValidTipoDocumentoValidator<T> : DomainValidator<T>
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
