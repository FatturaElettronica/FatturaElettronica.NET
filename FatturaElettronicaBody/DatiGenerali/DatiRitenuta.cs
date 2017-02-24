using FatturaElettronica.Common;
using System.Xml;

namespace FatturaElettronica.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati relativi alla ritenuta.
    /// </summary>
    public class DatiRitenuta : BaseClassSerializable
    {
        public DatiRitenuta() { }
        public DatiRitenuta(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Tipologia della ritenuta.
        /// </summary>
        [DataProperty]
        public string TipoRitenuta { get; set; }
        
        /// <summary>
        /// Importo dellla ritenuta.
        /// </summary>
        [DataProperty]
        public decimal? ImportoRitenuta { get; set; }
        
        /// <summary>
        /// Aliquota (%) della ritenuta.
        /// </summary>
        [DataProperty]
        public decimal? AliquotaRitenuta { get; set; }
        
        /// <summary>
        /// Causale del pagamento (quella del modello 770).
        /// </summary>
        [DataProperty]
        public string CausalePagamento { get; set; }
    }
}
