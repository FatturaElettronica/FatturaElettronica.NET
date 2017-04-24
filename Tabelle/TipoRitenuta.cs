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
                };
            }
        }
    }
}