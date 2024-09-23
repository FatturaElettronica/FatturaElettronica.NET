using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public abstract class Tabella
    {
        private static readonly ConcurrentDictionary<string, HashSet<string>> CodiciCache = new();

        public string Nome { get; set; }
        public string Codice { get; protected internal set; }
        public string Descrizione { get { return Codice + " " + Nome; } }
        public HashSet<string> Codici
        {
            get { return CodiciCache.GetOrAdd(GetType().Name, n => new(List.Select(l => l.Codice).Distinct())); }
        }
        public abstract Tabella[] List { get; }
    }

    public abstract class TabellaV2<T> : Tabella where T : Tabella, new()
    {
        protected abstract ResourceManager ResourceManager { get; }

        public override Tabella[] List
        {
            get
            {
                var resourceSet = ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                var enumerator = resourceSet.GetEnumerator();
                using var enumerator1 = enumerator as IDisposable;

                var count = 0;
                while (enumerator.MoveNext())
                {
                    count++;
                }

                var resourcesArray = new T[count];
                enumerator.Reset();
                var index = 0;
                while (enumerator.MoveNext())
                {
                    resourcesArray[index] = new T { Codice = enumerator.Key.ToString(), Nome = enumerator.Value.ToString() };
                    index++;
                }

                return resourcesArray;
            }
        }
    }
}
