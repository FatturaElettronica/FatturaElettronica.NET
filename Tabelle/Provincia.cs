using System.Resources;

namespace FatturaElettronica.Tabelle
{
    /// <summary>
    /// Attualmente non usata in convalida, vedo:
    /// https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/129
    /// /// </summary>
    public class Provincia : Tabella<Provincia>
    {
        protected override ResourceManager ResourceManager => Resources.Provincia.ResourceManager;
    }
}
