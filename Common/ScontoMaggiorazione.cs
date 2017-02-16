using FatturaElettronica.BusinessObjects;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Eventuale sconto o maggiorazione applicati sul totale documento.
    /// </summary>
    public class ScontoMaggiorazione : BusinessObject
    {
        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.
        
        /// <summary>
        /// Indica se trattasi di sconto o di maggiorazione.
        /// </summary>
        [DataProperty]
        public string Tipo { get; set; }

        /// <summary>
        /// Percentuale di sconto o di maggiorazione.
        /// </summary>
        [DataProperty]
        public decimal? Percentuale { get; set; }

        /// <summary>
        /// Importo dello sconto o della maggiorazione.
        /// </summary>
        [DataProperty]
        public decimal? Importo { get; set; }
    }
}
