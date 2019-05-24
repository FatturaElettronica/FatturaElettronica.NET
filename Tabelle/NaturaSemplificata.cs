namespace FatturaElettronica.Tabelle
{
    public class NaturaSemplificata : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new NaturaSemplificata { Codice = "N1", Nome = "escluse ex art. 15" },
                    new NaturaSemplificata { Codice = "N2", Nome = "non soggette" },
                    new NaturaSemplificata { Codice = "N3", Nome = "non imponibili" },
                    new NaturaSemplificata { Codice = "N4", Nome = "esenti" },
                    new NaturaSemplificata { Codice = "N5", Nome = "regime del margine / IVA non esposta in fattura" },
                };
            }
        }
    }
}