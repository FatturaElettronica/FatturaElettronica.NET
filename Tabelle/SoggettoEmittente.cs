namespace FatturaElettronica.Tabelle
{
    public class SoggettoEmittente : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[]
                {
                    new SoggettoEmittente { Codice = "CC", Nome = "cessionario/committente" },
                    new SoggettoEmittente { Codice = "TZ", Nome = "terzo" }
                };
            }
        }
    }
}