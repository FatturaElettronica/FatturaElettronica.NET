using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore
{
    public class SedeCedentePrestatore : Common.Località
    {
        public SedeCedentePrestatore()
        {
            XmlOptions.ElementName = "Sede";
        } 
        public SedeCedentePrestatore(XmlReader r) : base(r) { } 
    }
}
