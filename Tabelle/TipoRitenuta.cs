namespace FatturaElettronica.Tabelle
{
    public class TipoRitenuta : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new TipoRitenuta { Codice = "RT01", Nome = "ritenuta persone fisiche" },
                    new TipoRitenuta { Codice = "RT02", Nome = "ritenuta persone giuridiche" },
                    new TipoRitenuta { Codice = "RT03", Nome = "contributo INPS" },
                    new TipoRitenuta { Codice = "RT04", Nome = "contributo ENASARCO" },
                    new TipoRitenuta { Codice = "RT05", Nome = "contributo ENPAM" },
                    new TipoRitenuta { Codice = "RT06", Nome = "altro contributo previdenziale" },
                };
            }
        }
    }
}