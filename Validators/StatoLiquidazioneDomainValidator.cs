namespace FatturaElettronica.Validators
{
    public class StatoLiquidazioneDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return Common.StatoLiquidazione.Codici;
            }
        }
    }
}
