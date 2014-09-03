using System.Xml;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Informazioni relative ai dati presenti sul sistema gestionale in uso presso la PA (Agenzie Fiscali) riguardanti la fase di ricezione.
    /// </summary>
    public class DatiRicezione : Common.DatiDocumento
    {

        public DatiRicezione() { }
        public DatiRicezione(XmlReader r) : base(r) { }
    }
}
