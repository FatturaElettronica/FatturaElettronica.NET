using FatturaElettronica.Common;
using System.Collections.Generic;
using System.Xml;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati generali del documento principale e dati dei documenti correlati.
    /// </summary>
    public class DatiGenerali : BaseClassSerializable
    {
        /// <summary>
        /// Dati generali del documento principale e dati dei documenti correlati.
        /// </summary>
        public DatiGenerali()
        {
            DatiGeneraliDocumento = new DatiGeneraliDocumento();
            DatiOrdineAcquisto = new List<DatiOrdineAcquisto>();
            DatiContratto = new List<DatiContratto>();
            DatiConvenzione = new List<DatiConvenzione>();
            DatiRicezione = new List<DatiRicezione>();
            DatiFattureCollegate = new List<DatiFattureCollegate>();
            DatiSAL = new List<DatiSAL>();
            DatiDDT = new List<DatiDDT>();
            DatiTrasporto = new DatiTrasporto();
            FatturaPrincipale = new FatturaPrincipale();
        }
        public DatiGenerali(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [DataProperty]
        public DatiGeneraliDocumento DatiGeneraliDocumento { get; set; }

        /// <summary>
        /// Informazioni relative agli ordini di acquisto.
        /// </summary>
        [DataProperty]
        public List<DatiOrdineAcquisto> DatiOrdineAcquisto { get; set; }

        /// <summary>
        /// Informazioni relative ai contratti.
        /// </summary>
        [DataProperty]
        public List<DatiContratto> DatiContratto { get; set; }

        /// <summary>
        /// Informazioni relative alle convenzioni.
        /// </summary>
        [DataProperty]
        public List<DatiConvenzione> DatiConvenzione { get; set; }

        /// <summary>
        /// Informazioni relative ai dati presenti sul sistema gestionale in uso presso la PA (Agenzie Fiscali) riguardanti la fase di ricezione.
        /// </summary>
        [DataProperty]
        public List<DatiRicezione> DatiRicezione { get; set; }

        /// <summary>
        /// Informazioni relative alle fatture precedentemente trasmesse e alle quali si collega il documento presente.
        /// Riguarda i casi di invio di nota di credito e/o di fatture di conguaglio a fronte di precedenti fatture di accounto.
        /// </summary>
        [DataProperty]
        public List<DatiFattureCollegate> DatiFattureCollegate { get; set; }

        /// <summary>
        /// Blocco da valorizzare nei casi di fattura per stato di avanzamento.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public List<DatiSAL> DatiSAL { get; set; }

        /// <summary>
        /// Da valorizzarei nei casi di fattura differita per indicare il documento con cui è stato consegnato il bene.
        /// I campi del blocco possono essere ripetuti se la fattura fa riferimento a più consegne e quindi a più documenti di trasporto.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public List<DatiDDT> DatiDDT { get; set; }

        /// <summary>
        /// Blocco da valorizzare nei casi di fattura accompagnatoria per inserire informazioni relative al trasporto.
        /// </summary>
        [DataProperty]
        public DatiTrasporto DatiTrasporto { get; set; }

        /// <summary>
        /// Da valorizzare nei casi di fatture per operazioni accessorie, emesse dagli autotrasportatori per usufruire delle
        /// agevolazioni in materia di registrazioni e pagamento dell'IVA.
        /// </summary>
        [DataProperty]
        public FatturaPrincipale FatturaPrincipale { get; set; }
    }
}
