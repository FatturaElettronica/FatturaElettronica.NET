using System;
using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiPagamento
{
    /// <summary>
    /// Dati di dettaglio del pagamento.
    /// </summary>
    public class DettaglioPagamento : BaseClassSerializable
    {
        public DettaglioPagamento() { }
        public DettaglioPagamento(XmlReader r) : base(r) { }

        /// <summary>
        /// Beneficiario del pagamento (utilizzabile se si intende indicare un beneficiario diverso dal cedente/prestatore).
        /// </summary>
        [Core.DataProperty]
        public string Beneficiario { get; set; }

        /// <summary>
        /// Modalità di pagamento.
        /// </summary>
        [Core.DataProperty]
        public string ModalitaPagamento { get; set; }

        /// <summary>
        /// Data dalla quale decorrono i termini di pagamento.
        /// </summary>
        [Core.DataProperty]
        public DateTime? DataRiferimentoTerminiPagamento { get; set; }

        /// <summary>
        /// Termini di pagamento espressi in giorni a partire dalla data di riferimento di cui al campo DataRiferimentoTerminiPagamento.
        /// Vale 0 per i gamenti a vista.
        /// </summary>
        [Core.DataProperty]
        public int? GiorniTerminiPagamento { get; set; }

        /// <summary>
        /// Data di scadenza del pagamento da indicare nei casi in cui ha senso sulla base delle condizioni di pagamento
        /// previste.
        /// </summary>
        [Core.DataProperty]
        public DateTime? DataScadenzaPagamento { get; set; }

        /// <summary>
        /// Importo relativo al pagamento.
        /// </summary>
        [Core.DataProperty]
        public decimal ImportoPagamento { get; set; }

        /// <summary>
        /// Nei casi di modalità di pagamento in cui ha senso l'indicazione dellìufficio postale.
        /// </summary>
        [Core.DataProperty]
        public string CodUfficioPostale { get; set; }

        /// <summary>
        /// Cognome del quietanziante (nel caso di campo ModalitaPagamento = MP04).
        /// </summary>
        [Core.DataProperty]
        public string CognomeQuietanzante { get; set; }

        /// <summary>
        /// Nome del quietanziante (nel caso di campo ModalitaPagamento = MP04).
        /// </summary>
        [Core.DataProperty]
        public string NomeQuietanzante { get; set; }

        /// <summary>
        /// Codice fiscale del quietanziante (nel caso di campo ModalitaPagamento = MP04).
        /// </summary>
        [Core.DataProperty]
        // ReSharper disable once InconsistentNaming
        public string CFQuietanzante { get; set; }

        /// <summary>
        /// Titolo del quietanziante (nel caso di campo ModalitaPagamento = MP04).
        /// </summary>
        [Core.DataProperty]
        public string TitoloQuietanzante { get; set; }

        /// <summary>
        /// Nome dell'istituto finanziario.
        /// </summary>
        [Core.DataProperty]
        public string IstitutoFinanziario { get; set; }

        /// <summary>
        /// International Bank Account Number (coordinata bancaria internazionale che consente di identificare, in maniera standard,
        /// il conto corrente del beneficiario).
        /// </summary>
        [Core.DataProperty]
        // ReSharper disable once InconsistentNaming
        public string IBAN { get; set; }

        /// <summary>
        /// Codice ABI.
        /// </summary>
        [Core.DataProperty]
        // ReSharper disable once InconsistentNaming
        public string ABI { get; set; }

        /// <summary>
        /// Codice CAB.
        /// </summary>
        [Core.DataProperty]
        // ReSharper disable once InconsistentNaming
        public string CAB { get; set; }

        /// <summary>
        /// Bank Identifier Code (codice che identifica la banca del destinatario).
        /// </summary>
        [Core.DataProperty]
        // ReSharper disable once InconsistentNaming
        public string BIC { get; set; }

        /// <summary>
        /// Ammontare dello sconto per pagamento anticipato.
        /// </summary>
        [Core.DataProperty]
        public decimal? ScontoPagamentoAnticipato { get; set; }

        /// <summary>
        /// Data limite stabilita per il pagamento anticipato.
        /// </summary>
        [Core.DataProperty]
        public DateTime? DataLimitePagamentoAnticipato { get; set; }

        /// <summary>
        /// Ammontare della penalità dovuta per pagamenti ritardati.
        /// </summary>
        [Core.DataProperty]
        public decimal? PenalitaPagamentiRitardati { get; set; }

        /// <summary>
        /// Data di decorrenza della penale.
        /// </summary>
        [Core.DataProperty]
        public DateTime? DataDecorrenzaPenale { get; set; }

        /// <summary>
        /// Codice per la riconciliazione degli incassi da parte del cedente/prestatore.
        /// </summary>
        [Core.DataProperty]
        public string CodicePagamento { get; set; }
    }
}
