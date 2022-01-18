using System.Text;
using System.Text.Json;

namespace FatturaElettronica.Extensions
{
    public static class JsonExtensions
    {
        public static void FromJson(this FatturaBase fattura, string json)
        {
            fattura.FromJson(new Utf8JsonReader(Encoding.UTF8.GetBytes(json)));
        }
    }
}