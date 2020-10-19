using System;
using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati generali del documento principale ed i dati dei documenti correlati.
    /// </summary>
    public class DatiGeneraliDocumento : BaseClassSerializable
    {
        /// <summary>
        /// Dati generali del documento principale ed i dati dei documenti correlati.
        /// </summary>
        public DatiGeneraliDocumento()
        {
            DatiRitenuta = new List<DatiRitenuta>();
            DatiBollo = new DatiBollo();
            DatiCassaPrevidenziale = new List<DatiCassaPrevidenziale>();
            ScontoMaggiorazione = new List<ScontoMaggiorazione>();
            Causale = new List<string>();
        }
        public DatiGeneraliDocumento(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [Core.DataProperty]
        public string TipoDocumento { get; set; }

        /// <summary>
        /// Codice espresso secondo lo standard ISO 4217 alpha-3:2001 della valuta utilizzata per l'indicazione degli importi.
        /// </summary>
        [Core.DataProperty]
        public string Divisa { get; set; }

        /// <summary>
        /// Data del documento.
        /// </summary>
        [Core.DataProperty]
        public DateTime Data { get; set; }

        /// <summary>
        /// Numero progressivo del documento.
        /// </summary>
        [Core.DataProperty]
        public string Numero { get; set; }

        /// <summary>
        /// Dati della ritenuta.
        /// </summary>
        [Core.DataProperty]
        public List<DatiRitenuta> DatiRitenuta { get; set; }

        /// <summary>
        /// Dati del bollo.
        /// </summary>
        [Core.DataProperty]
        public DatiBollo DatiBollo { get; set; }

        /// <summary>
        /// Blocco dati relativi alla cassa previdenziale di appartenenenza.
        /// </summary>
        [Core.DataProperty]
        public List<DatiCassaPrevidenziale> DatiCassaPrevidenziale { get; set; }

        /// <summary>
        /// Eventuali sconti o maggiorazioni applicati sul totale documento.
        /// </summary>
        [Core.DataProperty]
        public List<ScontoMaggiorazione> ScontoMaggiorazione { get; set; }

        /// <summary>
        /// Importo totale del documento al netto dell'eventuale sconto e comprensivo di imposta a debito del cessionario /committente.
        /// </summary>
        [Core.DataProperty]
        public decimal? ImportoTotaleDocumento { get; set; }

        /// <summary>
        /// Eventuale arrotondamento sul totale documento (ammette anche il segno negativo).
        /// </summary>
        [Core.DataProperty]
        public decimal? Arrotondamento { get; set; }

        /// <summary>
        /// Descrizione della causale del documento.
        /// </summary>
        [Core.DataProperty]
        public List<string> Causale { get; set; }

        /// <summary>
        /// Indica se il documento è stato emesso secondo modalità e termini stabiliti con decreto ministeriale ai sensi art. 73
        /// DPR 633/72 (ciò consente al cedente/prestatore l'emissione nello stesso anno di più documenti aventi lo stesso numero).
        /// </summary>
        [Core.DataProperty]
        public string Art73 { get; set; }
    }
}
