using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati relativi alla cassa previdenziale di appartenenza.
    /// </summary>
    public class DatiCassaPrevidenziale : BaseClassSerializable
    {
        public DatiCassaPrevidenziale() { }
        public DatiCassaPrevidenziale(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.
        
        /// <summary>
        /// Tipologia della cassa previdenziale di appartenenza.
        /// </summary>
        [Core.DataProperty]
        public string TipoCassa { get; set; }

        /// <summary>
        /// Aliquota (%) del contributo, se previsto, per la cassa di appartenenza.
        /// </summary>
        [Core.DataProperty]
        public decimal AlCassa { get; set; }

        /// <summary>
        /// Importo del contributo per la cassa di appartenenza.
        /// </summary>
        [Core.DataProperty]
        public decimal ImportoContributoCassa { get; set; }

        /// <summary>
        /// Importo sul quale applicare il contributo cassa previdenziale.
        /// </summary>
        [Core.DataProperty]
        public decimal ImponibileCassa { get; set; }

        /// <summary>
        /// Aliquota (%) IVA applicata.
        /// </summary>
        [Core.DataProperty]
        public decimal AliquotaIVA { get; set; }

        /// <summary>
        /// Indica se il contributo cassa è soggetto a ritenuta.
        /// </summary>
        [Core.DataProperty]
        public string Ritenuta { get; set; }

        /// <summary>
        /// Nei casi di Aliquota IVA pari a zero.
        /// </summary>
        [Core.DataProperty]
        public string Natura { get; set; }

        /// <summary>
        /// Codice identificativo ai fini amministrativo-contabili.
        /// </summary>
        [Core.DataProperty]
        public string RiferimentoAmministrazione { get; set; }
    }
}
