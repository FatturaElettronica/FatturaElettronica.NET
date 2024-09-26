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
                    new FormatoTrasmissione{ Codice = Defaults.FormatoTrasmissione.PubblicaAmministrazione, Nome = Resources.FormatoTrasmissione.PubblicaAmministrazione },
                    new FormatoTrasmissione{ Codice = Defaults.FormatoTrasmissione.Privati, Nome = Resources.FormatoTrasmissione.Privati },
                    new FormatoTrasmissione{ Codice = Defaults.FormatoTrasmissione.Semplificata, Nome = Resources.FormatoTrasmissione.Semplificata }
                };
            }
        }
    }
}