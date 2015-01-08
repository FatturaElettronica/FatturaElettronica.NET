using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;
using System.Collections.Generic;

namespace FatturaElettronicaPA
{
    public class FatturaElettronica : BusinessObject
    {
        // TODO override ReadXml and WriteXML in order to properly handle List<FatturaElettronicaBody>

        private readonly FatturaElettronicaHeader.FatturaElettronicaHeader _header;
        private readonly List<FatturaElettronicaBody.FatturaElettronicaBody> _body;

        /// <summary>
        /// Constructor.
        /// </summary>
        public FatturaElettronica() {
            _header = new FatturaElettronicaHeader.FatturaElettronicaHeader();
            _body = new List<FatturaElettronicaBody.FatturaElettronicaBody>();
        }

        public override void WriteXml(System.Xml.XmlWriter w)
        {
            w.WriteStartElement("p", GetType().Name, "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1");
            w.WriteAttributeString("versione","1.1");
            base.WriteXml(w);
            w.WriteEndElement();
        }

        public override void ReadXml(System.Xml.XmlReader r) {
            r.MoveToContent();
            base.ReadXml(r);
        }

        #region Properties 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Intestazione della comunicazione.
        /// </summary>
        [DataProperty]
        public FatturaElettronicaHeader.FatturaElettronicaHeader FatturaElettronicaHeader { 
            get { return _header; }
        }

        /// <summary>
        /// Lotto di fatture incluse nella comunicazione.
        /// </summary>
        /// <remarks>Il blocco ha molteciplità 1 nel caso di fattura singola; nel caso di lotto di fatture, si ripete
        /// per ogni fattura componente il lotto stesso.</remarks>
        [DataProperty]
        public List<FatturaElettronicaBody.FatturaElettronicaBody> FatturaElettronicaBody {
            get { return _body; }
        }

        #endregion
        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("FatturaElettronicaHeader"));
            rules.Add(new FRequiredValidator("FatturaElettronicaBody"));
            return rules;
        }

    }
}
