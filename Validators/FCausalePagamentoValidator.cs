using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    /// <summary>
    /// Validates FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.CausalePagamento
    /// </summary>
    public class FCausalePagamentoValidator : DomainValidator
    {

        private const string BrokenDescription = "Valori ammessi: codifiche come da Mod. 770S";

        /// <summary>
        /// Constructor.
        /// </summary>
        public FCausalePagamentoValidator() : this(null, BrokenDescription) { }
        public FCausalePagamentoValidator(string propertyName) : this(propertyName, BrokenDescription) { }
        public FCausalePagamentoValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = new[] {
                "A", "B", "C", "D", "E", "G", "H", "I", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W",
                "X", "Y", "Z", "L1", "M1", "O1", "V1"
            };
        }
    }
}
