using System;
using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati generali del documento principale ed i dati dei documenti correlati.
    /// </summary>
    public class DatiGeneraliDocumento : Common.BaseClassSerializable
    {

        private readonly DatiRitenuta _datiRitenuta;
        private readonly DatiBollo _datiBollo;
        private readonly List<DatiCassaPrevidenziale> _datiCassaPrevidenziale;
        private readonly List<ScontoMaggiorazione> _scontoMaggiorazione;
        private readonly List<string> _causale;

        /// <summary>
        /// Dati generali del documento principale ed i dati dei documenti correlati.
        /// </summary>
        public DatiGeneraliDocumento() {
            _datiRitenuta = new DatiRitenuta();
            _datiBollo = new DatiBollo();
            _datiCassaPrevidenziale = new List<DatiCassaPrevidenziale>();
            _scontoMaggiorazione = new List<ScontoMaggiorazione>();
            _causale = new List<string>();
        }
        public DatiGeneraliDocumento(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [DataProperty]
        public string TipoDocumento { get; set; }
        
        /// <summary>
        /// Codice espresso secondo lo standard ISO 4217 alpha-3:2001 della valuta utilizzata per l'indicazione degli importi.
        /// </summary>
        [DataProperty]
        public string Divisa { get; set; }
        
        /// <summary>
        /// Data del documento.
        /// </summary>
        [DataProperty]
        public DateTime Data { get; set; }
        
        /// <summary>
        /// Numero progressivo del documento.
        /// </summary>
        [DataProperty]
        public string Numero { get; set; }

        /// <summary>
        /// Dati della ritenuta.
        /// </summary>
        [DataProperty]
        public DatiRitenuta DatiRitenuta { get { return _datiRitenuta; } }

        /// <summary>
        /// Dati del bollo.
        /// </summary>
        [DataProperty]
        public DatiBollo DatiBollo { get { return _datiBollo; } }

        /// <summary>
        /// Blocco dati relativi alla cassa previdenziale di appartenenenza.
        /// </summary>
        [DataProperty]
        public List<DatiCassaPrevidenziale> DatiCassaPrevidenziale { get { return _datiCassaPrevidenziale; } }

        /// <summary>
        /// Eventuali sconti o maggiorazioni applicati sul totale documento.
        /// </summary>
        [DataProperty]
        public List<ScontoMaggiorazione> ScontoMaggiorazione { get { return _scontoMaggiorazione; } }

        /// <summary>
        /// Importo totale del documento al netto dell'eventuale sconto e comprensivo di imposta a debito del cessionario /committente.
        /// </summary>
        [DataProperty]
        public decimal? ImportoTotaleDocumento { get; set; }

        /// <summary>
        /// Eventuale arrotondamento sul totale documento (ammette anche il segno negativo).
        /// </summary>
        [DataProperty]
        public decimal? Arrotondamento { get; set; }

        /// <summary>
        /// Descrizione della causale del documento.
        /// </summary>
        [DataProperty]
        public List<string> Causale { get { return _causale; }}

        /// <summary>
        /// Indica se il documento è stato emesso secondo modalità e termini stabiliti con decreto ministeriale ai sensi art. 73
        /// DPR 633/72 (ciò consente al cedente/prestatore l'emissione nello stesso anno di più documenti aventi lo stesso numero).
        /// </summary>
        [DataProperty]
        public string Art73 { get; set; }
    }
}
