using System.Xml;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Informazioni relative alla convenzione.
    /// </summary>
    public class DatiConvenzione : Common.DatiDocumento
    {

        public DatiConvenzione() { }
        public DatiConvenzione(XmlReader r) : base(r) { }
    }
}
