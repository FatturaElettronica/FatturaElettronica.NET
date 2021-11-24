using System;
using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Da valorizzare nel caso di fattura accompagnatoria per inserire informazioni relative al trasporto.
    /// </summary>
    public class DatiTrasporto : BaseClassSerializable
    {
        /// <summary>
        /// Da valorizzare nel caso di fattura accompagnatoria per inserire informazioni relative al trasporto.
        /// </summary>
        public DatiTrasporto()
        {
            DatiAnagraficiVettore = new();
            IndirizzoResa = new();
        }
        public DatiTrasporto(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati fiscali e anagrafici del vettore.
        /// </summary>
        [Core.DataProperty]
        public DatiAnagraficiVettore DatiAnagraficiVettore { get; set; }

        /// <summary>
        /// Mezzo utilizzato per il trasporto.
        /// </summary>
        [Core.DataProperty]
        public string MezzoTrasporto { get; set; }

        /// <summary>
        /// Causale del trasporto.
        /// </summary>
        [Core.DataProperty]
        public string CausaleTrasporto { get; set; }

        /// <summary>
        /// Numero dei colli trasportati.
        /// </summary>
        [Core.DataProperty]
        public int? NumeroColli { get; set; }

        /// <summary>
        /// Descrizione (natura, qualità, aspetto...) relativa ai colli trasportati.
        /// </summary>
        [Core.DataProperty]
        public string Descrizione { get; set; }

        /// <summary>
        /// Unità di misura riferita al peso della merce.
        /// </summary>
        [Core.DataProperty]
        public string UnitaMisuraPeso { get; set; }

        /// <summary>
        /// Peso lordo della merce.
        /// </summary>
        [Core.DataProperty]
        public decimal? PesoLordo { get; set; }

        /// <summary>
        /// Peso netto della merce.
        /// </summary>
        [Core.DataProperty]
        public decimal? PesoNetto { get; set; }

        /// <summary>
        /// Data e ora del ritiro della merce.
        /// </summary>
        [Core.DataProperty]
        [Core.IgnoreXmlDateFormat]
        public DateTime? DataOraRitiro { get; set; }

        /// <summary>
        /// Data e ora del trasporto.
        /// </summary>
        [Core.DataProperty]
        public DateTime? DataInizioTrasporto { get; set; }

        /// <summary>
        /// Codifica del termine di resa espresso secondo lo standard ICC-Camera di Commercio Internazionale (Incoterms).
        /// </summary>
        [Core.DataProperty]
        public string TipoResa { get; set; }


        /// <summary>
        /// Indirizzo di resa.
        /// </summary>
        [Core.DataProperty]
        public IndirizzoResa IndirizzoResa { get; set; }

        /// <summary>
        /// Data e ora della consegna della merce.
        /// </summary>
        [Core.DataProperty]
        [Core.IgnoreXmlDateFormat]
        public DateTime? DataOraConsegna { get; set; }
    }
}
