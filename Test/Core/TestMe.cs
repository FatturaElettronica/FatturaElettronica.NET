using System;
using FatturaElettronica.Core;

namespace FatturaElettronica.Test.Core
{
    public class TestMe : BaseClassSerializable
    {
        [DataProperty]
        public string AString { get; set; }

        [DataProperty]
        public DateTime ADate { get; set; }

        [DataProperty]
        public decimal ADecimal { get; set; }

        [DataProperty]
        public byte[] AByteArray { get; set; }

        [DataProperty]
        public bool ABool { get; set; }

        [DataProperty]
        public SubTestMe SubTestMe { get; } = new();

        public override void WriteXml(System.Xml.XmlWriter w)
        {
            w.WriteStartElement("test");
            base.WriteXml(w);
            w.WriteEndElement();
        }
    }

    public class SubTestMe : BaseClassSerializable
    {
        [DataProperty]
        public string AString { get; set; }

        [DataProperty]
        public DateTime ADate { get; set; }

        [DataProperty]
        public decimal ADecimal { get; set; }

        [DataProperty]
        public byte[] AByteArray { get; set; }

        [DataProperty]
        public bool ABool { get; set; }
    }
}