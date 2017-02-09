namespace FatturaElettronica.Validators
{
    public class IsValidTipoResaValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.TipoResa().Codici;
            }
        }
    }
}
