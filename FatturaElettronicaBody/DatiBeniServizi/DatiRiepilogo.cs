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
            rules.Add(new DelegateValidator("Natura", " 00420: nel blocco DatiRiepilogo con EsigibilitaIVA uguale a S il campo Natura non può assumere valore N6.", ValidateAgainstErr00420));
            rules.Add(new DelegateValidator("Imposta", " 00421:  il valore del campo Imposta non risulta calcolato secondo le regole definite nelle specifiche tecniche.", ValidateAgainstErr00421));
            return rules;
        }

		/// <summary>
        /// Validate error 00420 from FatturaElettronicaPA v1.3
        /// </summary>
        /// <returns></returns>
		private bool ValidateAgainstErr00420()
        {
            return !(Natura == "N6" && EsigibilitaIVA == "S");
        }

		/// <summary>
        /// Validate error 00421 from FatturaElettronicaPA v1.3
        /// </summary>
        /// <returns></returns>
		private bool ValidateAgainstErr00421()
        {
            return (Imposta == decimal.Parse(((AliquotaIVA * ImponibileImporto) / 100).ToString("0.00")));
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
