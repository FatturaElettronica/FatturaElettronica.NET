using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente
{
    /// <summary>
    /// Dati relativi al cessionario/ committente.
    /// </summary>
    public class CessionarioCommittente : BaseClassSerializable
    {
        /// <summary>
        /// Dati relativi al cessionario / committente.
        /// </summary>
        public CessionarioCommittente()
        {
            IdentificativiFiscali = new();
            AltriDatiIdentificativi = new();
        }
        public CessionarioCommittente(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati fiscali del cessionario / committente.
        /// </summary>
        [Core.DataProperty]
        public IdentificativiFiscali IdentificativiFiscali { get; set; }

        /// <summary>
        /// Altri dati fiscali del cessionario / committente.
        /// </summary>
        [Core.DataProperty]
        public AltriDatiIdentificativi AltriDatiIdentificativi { get; set; }
    }
}
