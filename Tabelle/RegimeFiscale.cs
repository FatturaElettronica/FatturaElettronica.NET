using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class RegimeFiscale : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[]
                {
                    new RegimeFiscale { Codice = "RF01", Nome = "Ordinario" },
                    new RegimeFiscale { Codice = "RF02", Nome = "Contribuenti minimi (art.1, c.96-117, L. 244/07 )"},
                    new RegimeFiscale { Codice = "RF04", Nome = "Agricoltura e attività connesse e pesca (artt.34 e 34-bis, DPR 633/72 )"},
                    new RegimeFiscale { Codice = "RF05", Nome = "Vendita sali e tabacchi (art.74, c.1, DPR 633/72 )"},
                    new RegimeFiscale { Codice = "RF06", Nome = "Commercio fiammiferi (art.74, c.1, DPR 633/72 )"},
                    new RegimeFiscale { Codice = "RF07", Nome = "Editoria (art.74, c.1, DPR 633/72 )"},
                    new RegimeFiscale { Codice = "RF08", Nome = "Gestione servizi telefonia pubblica (art.74, c.1, DPR 633/72 )"},
                    new RegimeFiscale { Codice = "RF09", Nome = "Rivendita documenti di trasporto pubblico e di sosta (art.74, c.1, DPR 633/72 )"},
                    new RegimeFiscale { Codice = "RF10", Nome = "Intrattenimenti, giochi e altre attività di cui all atariffa allegata al DPR 640/72 (art.74, c.6, DPR 633/72 )"},
                    new RegimeFiscale { Codice = "RF11", Nome = "Agenzie viaggi e turismo (art.74-ter, DPR 633/72 )"},
                    new RegimeFiscale { Codice = "RF12", Nome = "Agriturismo (art.5, c.2 L. 413/91 )"},
                    new RegimeFiscale { Codice = "RF13", Nome = "Vendite a domicilio (art.25-bis, c.6, DPR 600/73 )"},
                    new RegimeFiscale { Codice = "RF14", Nome = "Rivendita beni usati, oggetti d'arte, d'antiquariato o da collezione (art.36, DL 41/95 )"},
                    new RegimeFiscale { Codice = "RF15", Nome = "Agenzie di vendite all'asta di oggetti d'arte, antiquariato o da collezione (art.40-bis, DL 41/95 )"},
                    new RegimeFiscale { Codice = "RF16", Nome = "IVA per cassa P.A. (art.6, c.5, DPR 633/72 )"},
                    new RegimeFiscale { Codice = "RF17", Nome = "IVA per cassa (art. 32-bis, DL 83/2012)"},
                    new RegimeFiscale { Codice = "RF18", Nome = "Altro" },
                    new RegimeFiscale { Codice = "RF19", Nome = "Regime forfettario (art.1, c.54-89, L. 190/2014 )" }
                };
            }
        }
    }
    
    public class RegimeFiscaleV2 : TabellaV2<RegimeFiscaleV2>
    {
        protected override ResourceManager ResourceManager => Resources.RegimeFiscale.ResourceManager;
    }
}