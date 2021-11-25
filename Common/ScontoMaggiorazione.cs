namespace FatturaElettronica.Common
{
    /// <summary>
    /// Eventuale sconto o maggiorazione applicati sul totale documento.
    /// </summary>
    public class ScontoMaggiorazione : Core.BaseClassSerializable
    {
        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.
        
        /// <summary>
        /// Indica se trattasi di sconto o di maggiorazione.
        /// </summary>
        [Core.DataProperty]
        public string Tipo { get; set; }

        /// <summary>
        /// Percentuale di sconto o di maggiorazione.
        /// </summary>
        [Core.DataProperty]
        public decimal? Percentuale { get; set; }

        /// <summary>
        /// Importo dello sconto o della maggiorazione.
        /// </summary>
        [Core.DataProperty]
        public decimal? Importo { get; set; }
    }
}
