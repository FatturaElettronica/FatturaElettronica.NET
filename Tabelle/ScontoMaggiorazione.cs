using System.Resources;

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
    
    public class ScontoMaggiorazioneV2 : TabellaV2<ScontoMaggiorazioneV2>
    {
        protected override ResourceManager ResourceManager => Resources.ScontoMaggiorazione.ResourceManager;
    }
}