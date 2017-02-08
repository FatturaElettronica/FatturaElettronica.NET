namespace FatturaElettronica.Tabelle
{
    public class ScontoMaggiorazione : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[]
                {
                    new ScontoMaggiorazione{ Codice = "SC", Nome = "sconto" },
                    new ScontoMaggiorazione{ Codice = "MG", Nome = "maggiorazione" }
                };
            }
        }
    }
}