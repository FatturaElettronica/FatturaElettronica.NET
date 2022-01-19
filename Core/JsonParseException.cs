using System;
using System.Text.Json;

namespace FatturaElettronica.Core
{
    /// <summary>
    /// Json parsing exception
    /// </summary>
    public class JsonParseException : Exception
    {
        private int LineNumber { get; }

        private int LinePosition { get; }

        public JsonParseException(string message, Utf8JsonReader reader) : base(message)
        {
            //Not available atm.
            //As mentioned here https://github.com/dotnet/runtime/issues/28482 will be available from System.Text.Json vers.7.0.0

            //LineNumber = textReader.LineNumber;
            //LinePosition = textReader.textReader;
        }
    }
}