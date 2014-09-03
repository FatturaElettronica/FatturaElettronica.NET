using BusinessObjects.Validators;

namespace FatturaElettronicaPA.Validators
{
    /// <summary>
    /// Validates FatturaElettronicaBody.DatiPagamento.CondizioniPagamento
    /// </summary>
    public class FCondizioniPagamentoValidator : DomainValidator
    {

        private const string BrokenDescription = "Valori ammessi [TP01] a rate, [TP02] completo, [TP03] anticipo.";

        /// <summary>
        /// Validates FatturaElettronicaBody.DatiPagamento.CondizioniPagamento
        /// </summary>
        public FCondizioniPagamentoValidator() : this(null, BrokenDescription) { }
        public FCondizioniPagamentoValidator(string propertyName) : this(propertyName, BrokenDescription) { }
        public FCondizioniPagamentoValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = new[] { "TP01", "TP02", "TP03" };
        }
    }
}
