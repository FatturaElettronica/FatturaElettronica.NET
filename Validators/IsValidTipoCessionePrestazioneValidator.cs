namespace FatturaElettronica.Validators
{
    public class IsValidTipoCessionePrestazioneValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.TipoCessionePrestazione().Codici;
            }
        }
    }
}
