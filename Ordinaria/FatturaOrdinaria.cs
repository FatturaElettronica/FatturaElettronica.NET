using System.Collections.Generic;
using FatturaElettronica.Common;
using FatturaElettronica.Defaults;

namespace FatturaElettronica.Ordinaria
{
    public class FatturaOrdinaria : FatturaBase
    {
        public FatturaOrdinaria()
        {
            FatturaElettronicaHeader = new FatturaElettronicaHeader.FatturaElettronicaHeader();
            FatturaElettronicaBody = new List<FatturaElettronicaBody.FatturaElettronicaBody>();
        }
        public static FatturaOrdinaria CreateInstance(Instance formato)
        {
            var fattura = new FatturaOrdinaria();

            switch (formato)
            {
                case Instance.PubblicaAmministrazione:
                    fattura.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = FormatoTrasmissione.PubblicaAmministrazione;
                    break;
                case Instance.Privati:
                    fattura = new FatturaOrdinaria();
                    fattura.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = FormatoTrasmissione.Privati;
                    fattura.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = new string('0', 7);
                    break;
            }

            return fattura;
        }

        public override string GetFormatoTrasmissione()
        {
            return FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione;
        }

        protected override string GetLocalName()
        {
            return "FatturaElettronica";
        }

        protected override string GetNameSpace()
        {
            return "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2";
        }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Intestazione della comunicazione.
        /// </summary>
        [Core.DataProperty]
        public FatturaElettronicaHeader.FatturaElettronicaHeader FatturaElettronicaHeader { get; set; }

        /// <summary>
        /// Lotto di fatture incluse nella comunicazione.
        /// </summary>
        /// <remarks>Il blocco ha molteciplità 1 nel caso di fattura singola; nel caso di lotto di fatture, si ripete
        /// per ogni fattura componente il lotto stesso.</remarks>
        [Core.DataProperty]
        public List<FatturaElettronicaBody.FatturaElettronicaBody> FatturaElettronicaBody { get; set; }

    }
}
