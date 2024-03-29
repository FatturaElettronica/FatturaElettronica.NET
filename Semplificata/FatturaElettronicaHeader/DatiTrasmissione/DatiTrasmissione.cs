﻿using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.DatiTrasmissione
{

    /// <summary>
    /// Informazioni che identificano univocamente il soggetto che trasmette, il documento trasmesso, 
    /// il formato in cui è stato trasmesso il documento, il soggetto destinatario.
    /// </summary>
    public class DatiTrasmissione : BaseClassSerializable
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public DatiTrasmissione()
        {
            IdTrasmittente = new();
        }
        public DatiTrasmissione(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Identificativo univoco del soggetto trasmittente.
        /// </summary>
        [Core.DataProperty]
        public IdTrasmittente IdTrasmittente { get; set; }

        /// <summary>
        /// Progressivo univoco, attribuito dal soggetto che trasmette, relativo ad ogni singolo documento fattura.
        /// </summary>
        [Core.DataProperty]
        public string ProgressivoInvio { get; set; }

        /// <summary>
        /// Codice identificativo del formato/versione con cui è stato trasmesso il documento fattura.
        /// </summary>
        [Core.DataProperty]
        public string FormatoTrasmissione { get; set; }

        /// <summary>
        /// Codice dell'ufficio dell'amministrazione dello stato destinatario della fattura, definito dall'amministrazione
        /// di appartenenza come riportato nella rubrica "Indice PA".
        /// </summary>
        [Core.DataProperty]
        public string CodiceDestinatario { get; set; }
        
        /// <summary>
        /// Inidirizzo PEC al quale inviare il documento.
        /// </summary>
        [Core.DataProperty]
        public string PECDestinatario { get; set; }
    }
}
