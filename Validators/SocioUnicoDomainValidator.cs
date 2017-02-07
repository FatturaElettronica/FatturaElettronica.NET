namespace FatturaElettronica.Validators
{
    public class SocioUnicoDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return Tabelle.SocioUnico.Codici;
            }
        }
    }
}
