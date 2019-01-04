using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace FatturaElettronica.Tabelle
{
    public abstract class Tabella : IEquatable<Tabella>
    {
        private static readonly ConcurrentDictionary<string, HashSet<string>> CodiciCache = new ConcurrentDictionary<string, HashSet<string>>();

        public string Nome { get; set; }
        public string Codice { get; protected set; }
        public string Descrizione { get { return Codice + " " + Nome; } }
        public HashSet<string> Codici
        {
            get { return CodiciCache.GetOrAdd(GetType().Name, n => new HashSet<string>(List.Select(l => l.Codice).Distinct())); }
        }
        public abstract Tabella[] List { get; }

        public bool Equals(Tabella other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Codice, other.Codice);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Tabella) obj);
        }

        public override int GetHashCode()
        {
            return Codice?.GetHashCode() ?? 0;
        }
    }
}