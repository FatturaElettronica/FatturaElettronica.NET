using BusinessObjects;

namespace FatturaElettronica.Validators
{
    public class TipoCassaDomainValidator<T> : DomainValidator<T>
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
