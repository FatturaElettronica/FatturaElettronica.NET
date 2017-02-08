using BusinessObjects;

namespace FatturaElettronica.Validators
{
    public class IsValidTipoCassaValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.TipoCassa().Codici;
            }
        }
    }
}
