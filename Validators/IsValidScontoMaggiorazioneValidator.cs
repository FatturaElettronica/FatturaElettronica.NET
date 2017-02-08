namespace FatturaElettronica.Validators
{
    public class IsValidScontoMaggiorazioneValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.ScontoMaggiorazione().Codici;
            }
        }
    }
}
