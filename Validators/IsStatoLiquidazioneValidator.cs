namespace FatturaElettronica.Validators
{
    public class IsStatoLiquidazioneValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.StatoLiquidazione().Codici;
            }
        }
    }
}
