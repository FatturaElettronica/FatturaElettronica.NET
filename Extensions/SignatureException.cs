using System;

namespace FatturaElettronica.Extensions
{
    public class SignatureException : Exception
    {
        public SignatureException(string message) : base(message) { }
    }
}
