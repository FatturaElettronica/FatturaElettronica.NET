using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class NaturaSemplificata : Tabella<NaturaSemplificata>
    {
        protected override ResourceManager ResourceManager => Resources.NaturaSemplificata.ResourceManager;
    }
}
