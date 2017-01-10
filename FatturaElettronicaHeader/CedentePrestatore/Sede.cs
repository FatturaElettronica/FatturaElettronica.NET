using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore
{
    public class Sede : Common.Località
    {
        public Sede() { } 
        public Sede(XmlReader r) : base(r) { } 
    }
}
