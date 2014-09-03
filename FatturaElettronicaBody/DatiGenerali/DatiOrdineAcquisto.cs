using System.Xml;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Informazioni relative all'ordine di acquisto.
    /// </summary>
    public class DatiOrdineAcquisto : Common.DatiDocumento
    {

        public DatiOrdineAcquisto() { }
        public DatiOrdineAcquisto(XmlReader r) : base(r) { }
    }
}
