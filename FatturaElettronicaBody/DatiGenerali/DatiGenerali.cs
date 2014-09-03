using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{

    /// <summary>
    /// Dati generali del documento principale e dati dei documenti correlati.
    /// </summary>
    public class DatiGenerali : Common.BusinessObject
    {
        private readonly DatiGeneraliDocumento _datiGeneraliDocumento;
        private readonly List<DatiOrdineAcquisto> _datiOrdineAcquisto;
        private readonly List<DatiContratto> _datiContratto;
        private readonly List<DatiConvenzione> _datiConvenzione;
        private readonly List<DatiRicezione> _datiRicezione;
        private readonly List<DatiFattureCollegate> _datiFattureCollegate;
        // ReSharper disable once InconsistentNaming
        private readonly List<DatiSAL> _datiSAL;
        // ReSharper disable once InconsistentNaming
        private readonly List<DatiDDT> _datiDDT;
        private readonly DatiTrasporto _datiTrasporto;
        private readonly FatturaPrincipale _fatturaPrincipale;

        /// <summary>
        /// Dati generali del documento principale e dati dei documenti correlati.
        /// </summary>
        public DatiGenerali() {
            _datiGeneraliDocumento = new DatiGeneraliDocumento();
            _datiOrdineAcquisto = new List<DatiOrdineAcquisto>();
            _datiContratto = new List<DatiContratto>();
            _datiConvenzione = new List<DatiConvenzione>();
            _datiRicezione = new List<DatiRicezione>();
            _datiFattureCollegate = new List<DatiFattureCollegate>();
            _datiSAL = new List<DatiSAL>();
            _datiDDT = new List<DatiDDT>();
            _datiTrasporto = new DatiTrasporto();
            _fatturaPrincipale = new FatturaPrincipale();
        }
        public DatiGenerali(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("DatiGeneraliDocumento"));
            rules.Add(new FLengthValidator("NormaDiRiferimento", 1, 100));
            return rules;
        }

        #region Properties 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [DataProperty]
        public DatiGeneraliDocumento DatiGeneraliDocumento { get { return _datiGeneraliDocumento; } }

        /// <summary>
        /// Informazioni relative agli ordini di acquisto.
        /// </summary>
        [DataProperty]
        public List<DatiOrdineAcquisto> DatiOrdineAcquisto { get { return _datiOrdineAcquisto; } }

        /// <summary>
        /// Informazioni relative ai contratti.
        /// </summary>
        [DataProperty]
        public List<DatiContratto> DatiContratto { get { return _datiContratto; } }

        /// <summary>
        /// Informazioni relative alle convenzioni.
        /// </summary>
        [DataProperty]
        public List<DatiConvenzione> DatiConvenzione { get { return _datiConvenzione; } }

        /// <summary>
        /// Informazioni relative ai dati presenti sul sistema gestionale in uso presso la PA (Agenzie Fiscali) riguardanti la fase di ricezione.
        /// </summary>
        [DataProperty]
        public List<DatiRicezione> DatiRicezione { get { return _datiRicezione; } }

        /// <summary>
        /// Informazioni relative alle fatture precedentemente trasmesse e alle quali si collega il documento presente.
        /// Riguarda i casi di invio di nota di credito e/o di fatture di conguaglio a fronte di precedenti fatture di accounto.
        /// </summary>
        [DataProperty]
        public List<DatiFattureCollegate> DatiFattureCollegate { get { return _datiFattureCollegate; } }

        /// <summary>
        /// Blocco da valorizzare nei casi di fattura per stato di avanzamento.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public List<DatiSAL> DatiSAL { get { return _datiSAL; } }

        /// <summary>
        /// Da valorizzarei nei casi di fattura differita per indicare il documento con cui è stato consegnato il bene.
        /// I campi del blocco possono essere ripetuti se la fattura fa riferimento a più consegne e quindi a più documenti di trasporto.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public List<DatiDDT> DatiDDT { get { return _datiDDT; } }

        /// <summary>
        /// Blocco da valorizzare nei casi di fattura accompagnatoria per inserire informazioni relative al trasporto.
        /// </summary>
        [DataProperty]
        public DatiTrasporto DatiTrasporto { get { return _datiTrasporto; } }

        /// <summary>
        /// Da valorizzare nei casi di reverse charge (autofattura); contiene la norma di riferimento, comunitaria o nazionale, nei
        /// casi in cui il cessionario/committente è debitore di imposta in luogo del cedente/prestatore; negli altri casi il campo
        /// non va valorizzato.
        /// </summary>
        [DataProperty]
        public string NormaDiRiferimento { get; set; }

        /// <summary>
        /// Da valorizzare nei casi di fatture per operazioni accessorie, emesse dagli autotrasportatori per usufruire delle
        /// agevolazioni in materia di registrazioni e pagamento dell'IVA.
        /// </summary>
        [DataProperty]
        public FatturaPrincipale FatturaPrincipale { get { return _fatturaPrincipale; } }

        #endregion
        }
}
