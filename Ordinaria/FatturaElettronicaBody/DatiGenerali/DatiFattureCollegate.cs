using System.Xml;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Informazioni relative alle fatture precedentemente trasmesse e alle quali si collega il documento presente.
    /// </summary>
    /// <remarks>Riguarda i casi di invio di nota di credito e/o fatture di conguaglio a fronte di precedenti fatture di acconto.</remarks>
    public class DatiFattureCollegate : Common.DatiDocumento
    {
        public DatiFattureCollegate() { }
        public DatiFattureCollegate(XmlReader r) : base(r) { }

    }
}
