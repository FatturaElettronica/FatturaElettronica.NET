using System.Xml;

namespace FatturaElettronica.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Informazioni relative al contratto.
    /// </summary>
    public class DatiContratto : Common.DatiDocumento
    {

        public DatiContratto() { }
        public DatiContratto(XmlReader r) : base(r) { }


    }
}
