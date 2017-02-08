namespace FatturaElettronica.Validators
{
    public class CausalePagamentoDomainValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.CausalePagamento().Codici;
            }
        }
    }
}
