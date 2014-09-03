using System;
using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiPagamento
{
    /// <summary>
    /// Dati di dettaglio del pagamento.
    /// </summary>
    public class DettaglioPagamento : Common.BusinessObject
    {
        public DettaglioPagamento() { }
        public DettaglioPagamento(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FLengthValidator("Beneficiario", 1, 200));
            rules.Add(new AndCompositeValidator("ModalitaPagamento",
                new List<Validator> {new FRequiredValidator(), new FModalitaPagamentoValidator()}));
            rules.Add(new FRequiredValidator("ImportoPagamento"));
            rules.Add(new FLengthValidator("CodUfficioPostale", 1, 20));
            rules.Add(new FLengthValidator("CognomeQuietanzante", 1, 60));
            rules.Add(new FLengthValidator("NomeQuietanzante", 1, 60));
            rules.Add(new FLengthValidator("CFQuietanzante", 16));
            rules.Add(new FLengthValidator("TitoloQuietanzante", 2, 10));
            rules.Add(new FLengthValidator("IstitutoFinanziario", 1, 60));
            rules.Add(new FLengthValidator("IBAN", 27, 34));
            rules.Add(new FLengthValidator("ABI", 5));
            rules.Add(new FLengthValidator("CAB", 5));
            rules.Add(new FLengthValidator("BIC", 8, 11));
            rules.Add(new FLengthValidator("CodicePagamento", 1, 15));
            return rules;
        }

        #region Properties
        /// <summary>
        /// Beneficiario del pagamento (utilizzabile se si intende indicare un beneficiario diverso dal cedente/prestatore).
        /// </summary>
        [DataProperty]
        public string Beneficiario { get; set; }

        /// <summary>
        /// Modalità di pagamento.
        /// </summary>
        [DataProperty]
        public string ModalitaPagamento { get; set; }

        /// <summary>
        /// Data dalla quale decorrono i termini di pagamento.
        /// </summary>
        [DataProperty]
        public DateTime? DataRiferimentoTerminiPagamento { get; set; }

        /// <summary>
        /// Termini di pagamento espressi in giorni a partire dalla data di riferimento di cui al campo DataRiferimentoTerminiPagamento.
        /// Vale 0 per i gamenti a vista.
        /// </summary>
        [DataProperty]
        public int? GiorniTerminiPagamento { get; set; }

        /// <summary>
        /// Data di scadenza del pagamento da indicare nei casi in cui ha senso sulla base delle condizioni di pagamento
        /// previste.
        /// </summary>
        [DataProperty]
        public DateTime DataScadenzaPagamento { get; set; }

        /// <summary>
        /// Importo relativo al pagamento.
        /// </summary>
        [DataProperty]
        public decimal ImportoPagamento { get; set; }

        /// <summary>
        /// Nei casi di modalità di pagamento in cui ha senso l'indicazione dellìufficio postale.
        /// </summary>
        [DataProperty]
        public string CodUfficioPostale { get; set; }

        /// <summary>
        /// Cognome del quietanziante (nel caso di campo ModalitaPagamento = MP04).
        /// </summary>
        [DataProperty]
        public string CognomeQuietanzante { get; set; }

        /// <summary>
        /// Nome del quietanziante (nel caso di campo ModalitaPagamento = MP04).
        /// </summary>
        [DataProperty]
        public string NomeQuietanzante { get; set; }

        /// <summary>
        /// Codice fiscale del quietanziante (nel caso di campo ModalitaPagamento = MP04).
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string CFQuietanzante { get; set; }

        /// <summary>
        /// Titolo del quietanziante (nel caso di campo ModalitaPagamento = MP04).
        /// </summary>
        [DataProperty]
        public string TitoloQuietanzante { get; set; }

        /// <summary>
        /// Nome dell'istituto finanziario.
        /// </summary>
        [DataProperty]
        public string IstitutoFinanziario { get; set; }

        /// <summary>
        /// International Bank Account Number (coordinata bancaria internazionale che consente di identificare, in maniera standard,
        /// il conto corrente del beneficiario).
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string IBAN { get; set; }

        /// <summary>
        /// Codice ABI.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string ABI { get; set; }

        /// <summary>
        /// Codice CAB.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string CAB { get; set; }

        /// <summary>
        /// Bank Identifier Code (codice che identifica la banca del destinatario).
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string BIC { get; set; }

        /// <summary>
        /// Ammontare dello sconto per pagamento anticipato.
        /// </summary>
        [DataProperty]
        public decimal? ScontoPagamentoAnticipato { get; set; }

        /// <summary>
        /// Data limite stabilita per il pagamento anticipato.
        /// </summary>
        [DataProperty]
        public decimal? DataLimitePagamentoAnticipato { get; set; }

        /// <summary>
        /// Ammontare della penalità dovuta per pagamenti ritardati.
        /// </summary>
        [DataProperty]
        public decimal? PenalitaPagamentiRitardati { get; set; }

        /// <summary>
        /// Data di decorrenza della penale.
        /// </summary>
        [DataProperty]
        public DateTime? DataDecorrenzaPenale { get; set; }

        /// <summary>
        /// Codice per la riconciliazione degli incassi da parte del cedente/prestatore.
        /// </summary>
        [DataProperty]
        public string CodicePagamento { get; set; }
        #endregion
    }
}
