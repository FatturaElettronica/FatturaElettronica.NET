using System.Xml;
using FatturaElettronica.BusinessObjects;

namespace FatturaElettronica.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati relativi alla cassa previdenziale di appartenenza.
    /// </summary>
    public class DatiCassaPrevidenziale : Common.BusinessObject
    {
        public DatiCassaPrevidenziale() { }
        public DatiCassaPrevidenziale(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.
        
        /// <summary>
        /// Tipologia della cassa previdenziale di appartenenza.
        /// </summary>
        [DataProperty]
        public string TipoCassa { get; set; }

        /// <summary>
        /// Aliquota (%) del contributo, se previsto, per la cassa di appartenenza.
        /// </summary>
        [DataProperty]
        public decimal AlCassa { get; set; }

        /// <summary>
        /// Importo del contributo per la cassa di appartenenza.
        /// </summary>
        [DataProperty]
        public decimal ImportoContributoCassa { get; set; }

        /// <summary>
        /// Importo sul quale applicare il contributo cassa previdenziale.
        /// </summary>
        [DataProperty]
        public decimal ImponibileCassa { get; set; }

        /// <summary>
        /// Aliquota (%) IVA applicata.
        /// </summary>
        [DataProperty]
        public decimal AliquotaIVA { get; set; }

        /// <summary>
        /// Indica se il contributo cassa è soggetto a ritenuta.
        /// </summary>
        [DataProperty]
        public string Ritenuta { get; set; }

        /// <summary>
        /// Nei casi di Aliquota IVA pari a zero.
        /// </summary>
        [DataProperty]
        public string Natura { get; set; }

        /// <summary>
        /// Codice identificativo ai fini amministrativo-contabili.
        /// </summary>
        [DataProperty]
        public string RiferimentoAmministrazione { get; set; }
    }
}
