using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class Divisa : Tabella<Divisa>
    {
        protected override ResourceManager ResourceManager => Resources.Divisa.ResourceManager;
    }
}
