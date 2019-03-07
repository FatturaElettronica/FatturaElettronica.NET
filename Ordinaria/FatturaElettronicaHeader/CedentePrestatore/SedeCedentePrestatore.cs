using System.Xml;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore
{
    public class SedeCedentePrestatore : Common.Località
    {
        public SedeCedentePrestatore() { } 
        public SedeCedentePrestatore(XmlReader r) : base(r) { } 
    }
}
