using System.Xml;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{
    public class IndirizzoResa : Common.Località
    {
        public IndirizzoResa() { } 
        public IndirizzoResa(XmlReader r) : base(r) { } 
    }
}
