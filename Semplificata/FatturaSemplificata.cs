using System.Collections.Generic;
using FatturaElettronica.Common;
using FatturaElettronica.Defaults;

namespace FatturaElettronica.Semplificata
{
    public class FatturaSemplificata : FatturaBase
    {
        public FatturaSemplificata()
        {
            FatturaElettronicaHeader = new FatturaElettronicaHeader.FatturaElettronicaHeader();
            FatturaElettronicaBody = new List<FatturaElettronicaBody.FatturaElettronicaBody>();
        }

        public static FatturaSemplificata CreateInstance(Instance formato)
        {

            var fatturaSemplificata = new FatturaSemplificata();

            switch (formato)
            {
                case Instance.Semplificata:
                    fatturaSemplificata.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = FormatoTrasmissione.Semplificata;
                    fatturaSemplificata.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = new string('0', 7);
                    break;
            }

            return fatturaSemplificata;
        }

        protected override string GetFormatoTrasmissione()
        {
            return FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione;
        }

        protected override string GetLocalName()
        {
            return "FatturaElettronicaSemplificata";
        }

        protected override string GetNameSpace()
        {
            return "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.0";
        }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Intestazione della comunicazione.
        /// </summary>
        [DataProperty]
        public FatturaElettronicaHeader.FatturaElettronicaHeader FatturaElettronicaHeader { get; set; }

        /// <summary>
        /// Lotto di fatture incluse nella comunicazione.
        /// </summary>
        /// <remarks>Il blocco ha molteciplità 1 nel caso di fattura singola; nel caso di lotto di fatture, si ripete
        /// per ogni fattura componente il lotto stesso.</remarks>
        [DataProperty]
        public List<FatturaElettronicaBody.FatturaElettronicaBody> FatturaElettronicaBody { get; set; }
    }
}