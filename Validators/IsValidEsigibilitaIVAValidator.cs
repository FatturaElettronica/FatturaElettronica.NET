namespace FatturaElettronica.Validators
{
    public class IsValidEsigibilitaIVAValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.EsigibilitaIVA().Codici;
            }
        }
    }
}
