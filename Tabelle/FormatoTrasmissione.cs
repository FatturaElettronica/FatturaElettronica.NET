namespace FatturaElettronica.Tabelle
{
    public class FormatoTrasmissione : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[]
                {
                    new FormatoTrasmissione{ Codice = Defaults.FormatoTrasmissione.PubblicaAmministrazione, Nome = "FatturaOrdinaria verso la PA" },
                    new FormatoTrasmissione{ Codice = Defaults.FormatoTrasmissione.Privati, Nome = "FatturaOrdinaria verso privati" },
                    new FormatoTrasmissione{ Codice = Defaults.FormatoTrasmissione.Semplificata, Nome = "FatturaOrdinaria verso privati in forma semplificata" }
                };
            }
        }
    }
}