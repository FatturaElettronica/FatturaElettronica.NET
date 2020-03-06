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
                    new Natura { Codice = "N2.1", Nome = "non soggette ad IVA ai sensi degli artt. da 7 a 7-septies del DPR 633/72" },
                    new Natura { Codice = "N2.2", Nome = "non soggette – altri casi" },
                    new Natura { Codice = "N3", Nome = "non imponibili" },
                    new Natura { Codice = "N3.1", Nome = "non imponibili – esportazioni" },
                    new Natura { Codice = "N3.2", Nome = "non imponibili – cessioni intracomunitarie" },
                    new Natura { Codice = "N3.3", Nome = "non imponibili – cessioni verso San Marino" },
                    new Natura { Codice = "N3.4", Nome = "non imponibili – operazioni assimilate alle cessioni all’esportazione" },
                    new Natura { Codice = "N3.5", Nome = "non imponibili – a seguito di dichiarazioni d’intento" },
                    new Natura { Codice = "N3.6", Nome = "non imponibili – altre operazioni che non concorrono alla formazione del plafond" },
                    new Natura { Codice = "N4", Nome = "esenti" },
                    new Natura { Codice = "N5", Nome = "regime del margine / IVA non esposta in fattura" },
                    new Natura { Codice = "N6", Nome = "inversione contabile (per le operazioni in reverse charge ovvero nei casi di autofatturazione per acquisti extra UE di servizi ovvero per importazioni di beni nei soli casi previsti)" },
                    new Natura { Codice = "N6.1", Nome = "inversione contabile – cessione di rottami e altri materiali di recupero" },
                    new Natura { Codice = "N6.2", Nome = "inversione contabile – cessione di oro e argento puro" },
                    new Natura { Codice = "N6.3", Nome = "inversione contabile – subappalto nel settore edile" },
                    new Natura { Codice = "N6.4", Nome = "inversione contabile – cessione di fabbricati" },
                    new Natura { Codice = "N6.5", Nome = "inversione contabile – cessione di telefoni cellular" },
                    new Natura { Codice = "N6.6", Nome = "inversione contabile – cessione di prodotti elettronici" },
                    new Natura { Codice = "N6.7", Nome = "inversione contabile – prestazioni comparto edile e settori connessi" },
                    new Natura { Codice = "N6.8", Nome = "inversione contabile – operazioni settore energetico" },
                    new Natura { Codice = "N6.9", Nome = "inversione contabile – altri casi" },
                    new Natura { Codice = "N7", Nome = "IVA assolta in altro stato UE (vendite a distanza ex art.40 commi 3 e 4 e art. 41 comma 1 lett. b, DL 331/93; prestazione di servizi di telecomunicazioni, teleradiodiffusione ed elettronici ex art. 7-sexies lett. f, g, DPR 633/72 e art. 74-sexies, DPR 633/72)" }
                };
            } 
        }
    }
}