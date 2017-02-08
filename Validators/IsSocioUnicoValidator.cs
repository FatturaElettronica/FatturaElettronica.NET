namespace FatturaElettronica.Validators
{
    public class IsSocioUnicoValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.SocioUnico().Codici;
            }
        }
    }
}
