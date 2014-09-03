using System.Xml;
using FatturaElettronicaPA.Common;

namespace FatturaElettronicaPA.FatturaElettronicaHeader.DatiTrasmissione
{
    public class IdTrasmittente : IdFiscaleIVA
    {
        public IdTrasmittente() { }
        public IdTrasmittente(XmlReader r) : base(r) { }
    }
}
