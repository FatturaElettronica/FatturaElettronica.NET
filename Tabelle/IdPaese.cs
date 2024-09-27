using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class IdPaese : Tabella<IdPaese>
    {
        protected override ResourceManager ResourceManager => Resources.IdPaese.ResourceManager;
    }
}
