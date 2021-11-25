using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi
{
    /// <summary>
    /// Blocco sempre obbligatorio contenente i dati di riepilogo per ogni aliquota IVA o natura.
    /// </summary>
    public class DatiRiepilogo : BaseClassSerializable
    {
        public DatiRiepilogo() { }
        public DatiRiepilogo(XmlReader r) : base(r) { }

        /// <summary>
        /// Aliquota (%) IVA.
        /// </summary>
        [Core.DataProperty]
        public decimal AliquotaIVA { get; set; }

        /// <summary>
        /// Natura delle operazioni qualora non rientrino tra quelle imponibili.
        /// </summary>
        [Core.DataProperty]
        public string Natura { get; set; }

        /// <summary>
        /// Corrispettivi relativi alle cessioni accessorie (es. imballaggi etc.) qualora presenti.
        /// </summary>
        [Core.DataProperty]
        public decimal? SpeseAccessorie { get; set; }

        /// <summary>
        /// Arrotondamento sull'imponibili o sull'imposta.
        /// </summary>
        [Core.DataProperty]
        public decimal? Arrotondamento { get; set; }

        /// <summary>
        /// Questo valore rappresenta: base imponibile per le operazioni soggette ad IVA; importo, per le operazioni che non 
        /// rientrano tra quelle imponibili.
        /// </summary>
        [Core.DataProperty]
        public decimal ImponibileImporto { get; set; }

        /// <summary>
        /// Imposta risultante dall'applicazione dell'aliquota IVA all'imponibile.
        /// </summary>
        [Core.DataProperty]
        public decimal Imposta { get; set; }

        /// <summary>
        /// Eseigibilità IVA (immediata ai sensi Art. 6 comma 5 del DPR 633 1972, oppure differita).
        /// </summary>
        [Core.DataProperty]
        public string EsigibilitaIVA { get; set; }

        /// <summary>
        /// Norma di riferimento (obbligatoria nei casi in cui Natura è valorizzato).
        /// </summary>
        [Core.DataProperty]
        public string RiferimentoNormativo { get; set; }
    }
}
