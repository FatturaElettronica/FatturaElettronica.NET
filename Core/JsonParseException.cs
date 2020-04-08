using System;
using Newtonsoft.Json;

namespace FatturaElettronica.Core
{
    /// <summary>
    /// Json parsing exception
    /// </summary>
    public class JsonParseException : Exception
    {
        private int LineNumber { get; }
        private int LinePosition { get; }

        public JsonParseException(string message, JsonReader reader) : base(message)
        {
            if (!(reader is JsonTextReader textReader)) return;
            LineNumber = textReader.LineNumber;
            LinePosition = textReader.LinePosition;
        }
    }
}