namespace FatturaElettronica.Tabelle
{
    public class Natura : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new Natura { Codice = "N1", Nome = "escluse ex art. 15" },
                    new Natura { Codice = "N2", Nome = "non soggette" },
                    new Natura { Codice = "N3", Nome = "non imponibili" },
                    new Natura { Codice = "N4", Nome = "esenti" },
                    new Natura { Codice = "N5", Nome = "regime del margine / IVA non esposta in fattura" },
                    new Natura { Codice = "N6", Nome = "inversione contabile (reverse charge)" },
                    new Natura { Codice = "N7", Nome = "IVA assolta in altro stato UE" }
                };
            } 
        }
    }
}