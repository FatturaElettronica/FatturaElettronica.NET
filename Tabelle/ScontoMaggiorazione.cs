using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class ScontoMaggiorazione : Tabella<ScontoMaggiorazione>
    {
        protected override ResourceManager ResourceManager => Resources.ScontoMaggiorazione.ResourceManager;
    }
}
