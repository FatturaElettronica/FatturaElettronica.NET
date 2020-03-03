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
                    new NaturaSemplificata { Codice = "N2.1", Nome = "non soggette ad IVA ai sensi degli artt. da 7 a 7-septies del D.P.R. n. 633/72" },
                    new NaturaSemplificata { Codice = "N2.2", Nome = "non soggette - altri casi" },
                    new NaturaSemplificata { Codice = "N3", Nome = "non imponibili" },
                    new NaturaSemplificata { Codice = "N3.1", Nome = "non imponibili - esportazioni" },
                    new NaturaSemplificata { Codice = "N3.2", Nome = "non imponibili - cessioni intracomunitarie" },
                    new NaturaSemplificata { Codice = "N3.3", Nome = "non imponibili - cessioni verso San Marino" },
                    new NaturaSemplificata { Codice = "N3.4", Nome = "non imponibili - operazioni assimilate alle cessioni all'esportazione" },
                    new NaturaSemplificata { Codice = "N3.5", Nome = "non imponibili - a seguito di dichiarazioni d'intento" },
                    new NaturaSemplificata { Codice = "N3.6", Nome = "non imponibili - altre operazioni che non concorrono alla formazione del plafond" },
                    new NaturaSemplificata { Codice = "N4", Nome = "esenti" },
                    new NaturaSemplificata { Codice = "N5", Nome = "regime del margine / IVA non esposta in fattura" },
                };
            }
        }
    }
}