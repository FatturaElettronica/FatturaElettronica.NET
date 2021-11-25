using System;
using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Da valorizzare nei casi di fatture per operazione accessorie, emesse dagli autotraportatori per usufruire delle
    /// agevolazioni in mteria di registrazione e pagamento IVA.
    /// </summary>
    public class FatturaPrincipale : BaseClassSerializable
    {
        public FatturaPrincipale() { }
        public FatturaPrincipale(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.
        
        /// <summary>
        /// Numero della fattura relativa al trasporto di beni, da indicare sulle fatture emesse dagli autotrasportatori per
        /// certificare le operazioni accessorie.
        /// </summary>
        [Core.DataProperty]
        public string NumeroFatturaPrincipale { get; set; }
        

        /// <summary>
        /// Data della fattura relativa al trasporto di beni.
        /// </summary>
        [Core.DataProperty]
        public DateTime? DataFatturaPrincipale { get; set; }
    }
}
