using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;

namespace FatturaElettronica.FatturaElettronicaBody.Allegati
{
    /// <summary>
    /// Dati relativi ad eventuale allegato.
    /// </summary>
    public class Allegati : Common.BusinessObject
    {
        public Allegati() { }
        public Allegati(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new AndCompositeValidator("NomeAttachment", new List<Validator> {new FRequiredValidator(), new FLengthValidator(1, 60)}));
            rules.Add(new FLengthValidator("AlgoritmoCompressione", 1, 20));
            rules.Add(new FLengthValidator("FormatoAttachment", 1, 10));
            rules.Add(new FLengthValidator("DescrizioneAttachment", 1, 100));
            rules.Add(new FRequiredValidator("Attachment"));
            return rules;
        }

        #region Properties
        /// <summary>
        /// Nome dell'allegato.
        /// </summary>
        [DataProperty]
        public string NomeAttachment { get; set; }

        /// <summary>
        /// Algoritmo usato per comprimere l'attachment (ad es. ZIP, RAR, ...)
        /// </summary>
        [DataProperty]
        public string AlgoritmoCompressione { get; set; }

        /// <summary>
        /// Formato dell'attachment (ad es: TXT, XML, DOC, PDF, ...)
        /// </summary>
        [DataProperty]
        public string FormatoAttachment { get; set; }

        /// <summary>
        /// Descrizione del documento.
        /// </summary>
        [DataProperty]
        public string DescrizioneAttachment { get; set; }

        /// <summary>
        /// Contiene il documento allegato alla fattura; il contenuto è demandato agli accordi tra PA e fornitore.
        /// </summary>
        [DataProperty]
        public byte[] Attachment { get; set; }
        #endregion
    }
}
