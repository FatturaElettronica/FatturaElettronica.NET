using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using FatturaElettronica.Impostazioni;

[assembly:InternalsVisibleTo("Tests,"+
    "PublicKey=00240000048000009400000006020000002400005253413100040000010001002bc3d9fc3ae589"+
    "2f31b57e84fbd4c108035bdac32363b22691795307395ad82e43f3da76e95f6851190228e6dac9"+
    "5aa160072ea70ee1a62a01e1d5e905dd7845ece57d28eb2d63b366073740af1a05bc216ca0e205"+
    "b7974ffb2b21289125bcffdaa556f95d7891c0167eef5473d1e016cdac83acaa1b4da9fe9a2b2c"+
    "bf5200bf")]

namespace FatturaElettronica
{
    public class FatturaElettronica : BusinessObject
    {
        private readonly FatturaElettronicaHeader.FatturaElettronicaHeader _header;
        private readonly List<FatturaElettronicaBody.FatturaElettronicaBody> _body;

        protected FatturaElettronica() {
            _header = new FatturaElettronicaHeader.FatturaElettronicaHeader();
            _body = new List<FatturaElettronicaBody.FatturaElettronicaBody>();
        }

        public override void WriteXml(System.Xml.XmlWriter w)
        {
            w.WriteStartElement(RootElement.Prefix, RootElement.LocalName, RootElement.NameSpace);
            w.WriteAttributeString("versione", FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
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

        public static FatturaElettronica CreateInstance(Instance formato)
        {
            var f = new FatturaElettronica();

            switch (formato)
            {
                case Instance.PubblicaAmministrazione:
                    f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = FormatoTrasmissione.PubblicaAmministrazione;
                    break;
                case Instance.Privati:
                    f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = FormatoTrasmissione.Privati;
                    f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = new string('0', 7);
                    break;
            }

            return f;
        }

    }
}
