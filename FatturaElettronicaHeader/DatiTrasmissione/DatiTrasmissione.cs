using FatturaElettronica.Common;
using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione
{

    /// <summary>
    /// Informazioni che identificano univocamente il soggetto che trasmette, il documento trasmesso, 
    /// il formato in cui è stato trasmesso il documento, il soggetto destinatario.
    /// </summary>
    public class DatiTrasmissione : BaseClassSerializable
    {
        private readonly IdTrasmittente _idTrasmittente;
        private readonly ContattiTrasmittente _contattiTrasmittente;
        private string _progressivoInvio;
        private string _formatoTrasmissione;
        private string _codiceDestinatario;
        private string _pecDestinatario;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DatiTrasmissione() {
            _idTrasmittente = new IdTrasmittente();
            _contattiTrasmittente = new ContattiTrasmittente();
        }
        public DatiTrasmissione(XmlReader r) : base(r) { }

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

        /// <summary>
        /// Inidirizzo PEC al quale inviare il documento.
        /// </summary>
        [DataProperty]
        public string PECDestinatario { 
            get { return _pecDestinatario; }
            set {
                _pecDestinatario = CleanString(value);
                NotifyChanged();
            }
        }
    }
}
