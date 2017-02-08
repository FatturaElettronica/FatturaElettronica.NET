using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Validators
{
    public class IsValidTipoRitenutaValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new TipoRitenuta().Codici;
            }
        }
    }
}