using System.Xml;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.CedentePrestatore
{
    public class SedeCedentePrestatore : Common.Località
    {
        public SedeCedentePrestatore() { } 
        public SedeCedentePrestatore(XmlReader r) : base(r) { } 
    }
}
