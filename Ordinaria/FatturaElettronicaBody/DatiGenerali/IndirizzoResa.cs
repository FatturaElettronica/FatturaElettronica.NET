using System.Xml;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali
{
    public class IndirizzoResa : Common.Località
    {
        public IndirizzoResa() { } 
        public IndirizzoResa(XmlReader r) : base(r) { } 
    }
}
