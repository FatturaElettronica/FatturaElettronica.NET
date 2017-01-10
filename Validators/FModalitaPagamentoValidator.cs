using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    /// <summary>
    /// Validates FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento.
    /// </summary>
    public class FModalitaPagamentoValidator : DomainValidator
    {

        private const string BrokenDescription = "Valori ammessi [MP01], [MP02], [..], [MP21].";

        /// <summary>
        /// Validates FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento.
        /// </summary>
        public FModalitaPagamentoValidator() : this(null, BrokenDescription) { }
        public FModalitaPagamentoValidator(string propertyName) : this(propertyName, BrokenDescription) { }
        public FModalitaPagamentoValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = new[]
            {
                "MP01", "MP02", "MP03", "MP04", "MP05", "MP06", "MP07", "MP08", "MP09", "MP10", "MP11", "MP12", "MP13",
                "MP14", "MP15", "MP16", "MP17", "MP18", "MP19", "MP20", "MP21"
            };
        }
    }
}
