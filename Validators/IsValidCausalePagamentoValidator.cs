namespace FatturaElettronica.Validators
{
    public class IsValidCausalePagamentoValidator<T> : DomainValidator<T>
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
