using System.Linq;

namespace FatturaElettronica.Tabelle
{
    public abstract class Tabella
    {
        public string Nome { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get { return Codice + " " + Nome; } }
        public string[] Codici
        {
            get { return List.Select(x => x.Codice).ToArray(); }
        }
        public abstract Tabella[] List { get; }
    }
}