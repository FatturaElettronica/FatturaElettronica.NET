using System.Xml;

namespace FatturaElettronica.FatturaElettronicaBody.DatiGenerali
{
    public class IndirizzoResa : Common.Località
    {
        public IndirizzoResa() { } 
        public IndirizzoResa(XmlReader r) : base(r) { } 
    }
}
