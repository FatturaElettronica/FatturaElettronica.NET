namespace FatturaElettronica.Tabelle
{
    public class TipoRitenuta : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new TipoRitenuta { Codice = "RT01", Nome = "Ritenuta persone fisiche" },
                    new TipoRitenuta { Codice = "RT02", Nome = "Ritenuta persone giuridiche" },
                    new TipoRitenuta { Codice = "RT03", Nome = "Contributo INPS" },
                    new TipoRitenuta { Codice = "RT04", Nome = "Contributo ENASARCO" },
                    new TipoRitenuta { Codice = "RT05", Nome = "Contributo ENPAM" },
                    new TipoRitenuta { Codice = "RT06", Nome = "Altro contributo previdenziale" }
                };
            }
        }
    }
}