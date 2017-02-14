namespace FatturaElettronica.Validators
{
    public class IsValidModalitaPagamentoValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new Tabelle.ModalitaPagamento().Codici;
            }
        }
    }
}
