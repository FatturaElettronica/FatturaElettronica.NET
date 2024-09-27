using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class SoggettoEmittente : Tabella<SoggettoEmittente>
    {
        protected override ResourceManager ResourceManager => Resources.SoggettoEmittente.ResourceManager;
    }
}
