using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;
using System.Collections.Generic;
using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione
{

    /// <summary>
    /// Informazioni che identificano univocamente il soggetto che trasmette, il documento trasmesso, 
    /// il formato in cui è stato trasmesso il documento, il soggetto destinatario.
    /// </summary>
    public class DatiTrasmissione : Common.BusinessObject
    {
        private readonly IdTrasmittente _idTrasmittente;
        private readonly ContattiTrasmittente _contattiTrasmittente;
        private string _progressivoInvio;
        private string _formatoTrasmissione;
        private string _codiceDestinatario;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DatiTrasmissione() {
            _idTrasmittente = new IdTrasmittente();
            _contattiTrasmittente = new ContattiTrasmittente();
            _formatoTrasmissione = "FPA12";
        }
        public DatiTrasmissione(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("IdTrasmittente"));
            rules.Add(
                new AndCompositeValidator("ProgressivoInvio", 
                    new List<Validator> {new FRequiredValidator(), new FLengthValidator(1, 10)}));
            rules.Add(
                new AndCompositeValidator("FormatoTrasmissione", 
                    new List<Validator> {new FRequiredValidator(), new DomainValidator("Valori ammessi: [FPA12, FPR12]", Common.FormatoTrasmissione.Nomi) }));
            rules.Add(new AndCompositeValidator("CodiceDestinatario",
                    new List<Validator> {new FRequiredValidator(), new FLengthValidator(6) }));
            return rules;
        }

        #region Properties 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Identificativo univoco del soggetto trasmittente.
        /// </summary>
        [DataProperty]
        public IdTrasmittente IdTrasmittente { 
            get { return _idTrasmittente; }
        }

        /// <summary>
        /// Progressivo univoco, attribuito dal soggetto che trasmette, relativo ad ogni singolo documento fattura.
        /// </summary>
        [DataProperty]
        public string ProgressivoInvio {
            get { return _progressivoInvio; }
            set {
                _progressivoInvio = CleanString(value);
                NotifyChanged();
            }
        }

        /// <summary>
        /// Codice identificativo del formato/versione con cui è stato trasmesso il documento fattura.
        /// </summary>
        [DataProperty]
        public string FormatoTrasmissione {
            get { return _formatoTrasmissione; }
            set {
                _formatoTrasmissione = CleanString(value);
                NotifyChanged();
            }
        }

        /// <summary>
        /// Codice dell'ufficio dell'amministrazione dello stato destinatario della fattura, definito dall'amministrazione
        /// di appartenenza come riportato nella rubrica "Indice PA".
        /// </summary>
        [DataProperty]
        public string CodiceDestinatario {
            get { return _codiceDestinatario; }
            set {
                _codiceDestinatario = CleanString(value);
                NotifyChanged();
            }
        }

        /// <summary>
        /// Dati relativi ai contatti del trasmittente.
        /// </summary>
        [DataProperty]
        public ContattiTrasmittente ContattiTrasmittente { 
            get { return _contattiTrasmittente; }
        }
        #endregion
    }
}
