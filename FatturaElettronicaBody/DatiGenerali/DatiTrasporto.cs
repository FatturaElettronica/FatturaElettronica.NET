using System;
using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Da valorizzare nel caso di fattura accompagnatoria per inserire informazioni relative al trasporto.
    /// </summary>
    public class DatiTrasporto : Common.BusinessObject
    {
        private readonly DatiAnagraficiVettore _datiAnagraficiVettore;
        private readonly IndirizzoResa _indirizzoResa;

        /// <summary>
        /// Da valorizzare nel caso di fattura accompagnatoria per inserire informazioni relative al trasporto.
        /// </summary>
        public DatiTrasporto() {
            _datiAnagraficiVettore = new DatiAnagraficiVettore();
            _indirizzoResa = new IndirizzoResa();
        }
        public DatiTrasporto(XmlReader r) : base(r) { }

        // TODO: Implementare le regole per i DatiTrasporto
        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            
            return rules;
        }

        #region Properties

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.
        
        /// <summary>
        /// Dati fiscali e anagrafici del vettore.
        /// </summary>
        [DataProperty]
        public DatiAnagraficiVettore DatiAnagraficiVettore { get { return _datiAnagraficiVettore; } }

        /// <summary>
        /// Mezzo utilizzato per il trasporto.
        /// </summary>
        [DataProperty]
        public string MezzoTrasporto { get; set; }

        /// <summary>
        /// Causale del trasporto.
        /// </summary>
        [DataProperty]
        public string CausaleTrasporto { get; set; }

        /// <summary>
        /// Numero dei colli trasportati.
        /// </summary>
        [DataProperty]
        public int? NumeroColli { get; set; }

        /// <summary>
        /// Descrizione (natura, qualità, aspetto...) relativa ai colli trasportati.
        /// </summary>
        [DataProperty]
        public string Descrizione { get; set; }

        /// <summary>
        /// Unità di misura riferita al peso della merce.
        /// </summary>
        [DataProperty]
        public string UnitaMisuraPeso { get; set; }

        /// <summary>
        /// Peso lordo della merce.
        /// </summary>
        [DataProperty]
        public decimal? PesoLordo { get; set; }

        /// <summary>
        /// Peso netto della merce.
        /// </summary>
        [DataProperty]
        public decimal? PesoNetto { get; set; }

        /// <summary>
        /// Data e ora del ritiro della merce.
        /// </summary>
        [DataProperty]
        [IgnoreXmlDateFormat]
        public DateTime? DataOraRitiro { get; set; }

        /// <summary>
        /// Data e ora del trasporto.
        /// </summary>
        [DataProperty]
        public DateTime? DataInizioTrasporto { get; set; }

        /// <summary>
        /// Codifica del termine di resa espresso secondo lo standard ICC-Camera di Commercio Internazionale (Incoterms).
        /// </summary>
        [DataProperty]
        public string TipoResa { get; set; }


        /// <summary>
        /// Indirizzo di resa.
        /// </summary>
        [DataProperty]
        public IndirizzoResa IndirizzoResa { get { return _indirizzoResa; }}

        /// <summary>
        /// Data e ora della consegna della merce.
        /// </summary>
        [DataProperty]
        [IgnoreXmlDateFormat]
        public DateTime? DataOraConsegna { get; set; }
        #endregion
    }
}
