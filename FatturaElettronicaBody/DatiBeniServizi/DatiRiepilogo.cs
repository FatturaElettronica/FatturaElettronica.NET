using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiBeniServizi
{
    /// <summary>
    /// Blocco sempre obbligatorio contenente i dati di riepilogo per ogni aliquota IVA o natura.
    /// </summary>
    public class DatiRiepilogo : Common.BusinessObject
    {
        public DatiRiepilogo() { }
        public DatiRiepilogo(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("AliquotaIVA"));
            rules.Add(new FNaturaValidator("Natura"));
            rules.Add(new FRequiredValidator("ImponibileImporto"));
            rules.Add(new FRequiredValidator("Imposta"));
            rules.Add(new FEsigibilitaIVAValidator("EsigibilitaIVA"));
            return rules;
        }

        #region Properties
        /// <summary>
        /// Aliquota (%) IVA.
        /// </summary>
        [DataProperty]
        public decimal AliquotaIVA { get; set; }

        /// <summary>
        /// Natura delle operazioni qualora non rientrino tra quelle imponibili.
        /// </summary>
        [DataProperty]
        public string Natura { get; set; }

        /// <summary>
        /// Corrispettivi relativi alle cessioni accessorie (es. imballaggi etc.) qualora presenti.
        /// </summary>
        [DataProperty]
        public decimal? SpeseAccessorie { get; set; }

        /// <summary>
        /// Arrotondamento sull'imponibili o sull'imposta.
        /// </summary>
        [DataProperty]
        public decimal? Arrotondamento { get; set; }

        /// <summary>
        /// Questo valore rappresenta: base imponibile per le operazioni soggette ad IVA; importo, per le operazioni che non 
        /// rientrano tra quelle imponibili.
        /// </summary>
        [DataProperty]
        public decimal ImponibileImporto { get; set; }

        /// <summary>
        /// Imposta risultante dall'applicazione dell'aliquota IVA all'imponibile.
        /// </summary>
        [DataProperty]
        public decimal Imposta { get; set; }

        /// <summary>
        /// Eseigibilità IVA (immediata ai sensi Art. 6 comma 5 del DPR 633 1972, oppure differita).
        /// </summary>
        [DataProperty]
        public string EsigibilitaIVA { get; set; }

        /// <summary>
        /// Norma di riferimento (obbligatoria nei casi in cui Natura è valorizzato).
        /// </summary>
        [DataProperty]
        public string RiferimentoNormativo { get; set; }
        #endregion
    }
}
