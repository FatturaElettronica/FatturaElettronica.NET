namespace FatturaElettronica.Validators
{
    public class IsValidCondizioniPagamentoValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.CondizioniPagamento().Codici;
            }
        }
    }
}
