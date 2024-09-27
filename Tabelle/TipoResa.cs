using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class TipoResa : Tabella<TipoResa>
    {
        protected override ResourceManager ResourceManager => Resources.TipoResa.ResourceManager;
    }
}
