using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class SocioUnico : Tabella<SocioUnico>
    {
        protected override ResourceManager ResourceManager => Resources.SocioUnico.ResourceManager;
    }
}
