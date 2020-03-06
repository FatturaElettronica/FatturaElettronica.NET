﻿namespace FatturaElettronica.Defaults
{
    public enum Instance { PubblicaAmministrazione, Privati, Semplificata };
    public class Versione
    {
        public static string Trasmissione { get { return "1.2"; } }
        public static string Controlli { get { return "1.4"; } }
        public static string TrasmissioneSemplificata { get { return "1.0"; } }
    }
    public class FormatoTrasmissione
    {
        public static string PubblicaAmministrazione { get { return string.Format("FPA{0}", Versione.Trasmissione.Replace(".", "")); } }
        public static string Privati { get { return string.Format("FPR{0}", Versione.Trasmissione.Replace(".", "")); } }
        public static string Semplificata { get { return string.Format("FSM{0}", Versione.TrasmissioneSemplificata.Replace(".", "")); } }

    }
    public class RootElement
    {
        public static string Prefix { get { return "p"; } }
        public static XmlAttributeString[] ExtraAttributes
        {
            get
            {
                return new XmlAttributeString[] {
                    new XmlAttributeString { Prefix="xmlns", LocalName="ds", ns=null, value="http://www.w3.org/2000/09/xmldsig#"},
                    new XmlAttributeString { Prefix="xmlns", LocalName="xsi", ns=null, value="http://www.w3.org/2001/XMLSchema-instance"},
                    new XmlAttributeString { Prefix="xsi", LocalName="schemaLocation", ns=null, value="http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2 https://www.fatturapa.gov.it/export/fatturazione/sdi/fatturapa/v1.2.1/Schema_del_file_xml_FatturaPA_versione_1.2.1.xsd"}
                };
            }
        }
        public class XmlAttributeString
        {
            public string Prefix;
            public string LocalName;
            public string ns;
            public string value;
        }
    }
}
