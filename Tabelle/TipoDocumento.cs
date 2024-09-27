using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class TipoDocumento : Tabella<TipoDocumento>
    {
        protected override ResourceManager ResourceManager => Resources.TipoDocumento.ResourceManager;
    }
}
