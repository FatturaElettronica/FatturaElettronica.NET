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
                    new FormatoTrasmissione{ Codice = Impostazioni.FormatoTrasmissione.PubblicaAmministrazione, Nome = "Fattura verso la PA" },
                    new FormatoTrasmissione{ Codice = Impostazioni.FormatoTrasmissione.Privati, Nome = "Fattura verso privati" }
                };
            }
        }
    }
}