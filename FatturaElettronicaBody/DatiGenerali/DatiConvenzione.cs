using System.Xml;

namespace FatturaElettronica.FatturaElettronicaBody.DatiGenerali
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
