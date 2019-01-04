using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace FatturaElettronica.Tabelle
{
    public abstract class Tabella
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
    }
}