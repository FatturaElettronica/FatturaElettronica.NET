using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class RegimeFiscale : Tabella<RegimeFiscale>
    {
        protected override ResourceManager ResourceManager => Resources.RegimeFiscale.ResourceManager;
    }
}
