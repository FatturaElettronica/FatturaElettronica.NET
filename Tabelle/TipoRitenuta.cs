using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class TipoRitenuta : Tabella<TipoRitenuta>
    {
        protected override ResourceManager ResourceManager => Resources.TipoRitenuta.ResourceManager;
    }
}
