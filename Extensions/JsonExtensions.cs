using System.IO;

namespace FatturaElettronica.Extensions
{
    public static class JsonExtensions
    {
        public static void FromJson(this FatturaBase fattura, string json)
        {
            fattura.FromJson(new JsonTextReader(new StringReader(json)));
        }
    }
}