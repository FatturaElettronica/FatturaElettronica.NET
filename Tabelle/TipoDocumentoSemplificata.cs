using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class TipoDocumentoSemplificata : Tabella<TipoDocumentoSemplificata>
    {
        protected override ResourceManager ResourceManager => Resources.TipoDocumentoSemplificata.ResourceManager;
    }
}
