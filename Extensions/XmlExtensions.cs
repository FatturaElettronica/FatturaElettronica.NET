using System.IO;
using System.Xml;

namespace FatturaElettronica.Extensions
{
    public static class XmlExtensions
    {
        public static void ReadXml(this FatturaBase fattura, string filePath)
        {
            using var r = XmlReader.Create(filePath,
                new()
                {
                    IgnoreWhitespace = true, IgnoreComments = true, IgnoreProcessingInstructions = true
                });
            fattura.ReadXml(r);
        }

        public static void ReadXml(this FatturaBase fattura, Stream stream)
        {
            stream.Position = 0;
            using var r = XmlReader.Create(stream,
                new()
                {
                    IgnoreWhitespace = true, IgnoreComments = true, IgnoreProcessingInstructions = true
                });
            fattura.ReadXml(r);
        }

        public static void WriteXml(this FatturaBase fattura, string filePath)
        {
            using var w = XmlWriter.Create(filePath, new() {Indent = true});
            fattura.WriteXml(w);
        }
    }
}