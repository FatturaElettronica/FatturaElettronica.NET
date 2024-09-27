using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class Natura : Tabella<Natura>
    {
        protected override ResourceManager ResourceManager => Resources.Natura.ResourceManager;
    }
}
