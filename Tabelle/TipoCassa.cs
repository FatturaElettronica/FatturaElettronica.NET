using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class TipoCassa : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new TipoCassa { Codice = "TC01", Nome = "Cassa nazionale previdenza e assistenza avvocati e procuratori legali" },
                    new TipoCassa { Codice = "TC02", Nome = "Cassa previdenza dottori commercialisti" },
                    new TipoCassa { Codice = "TC03", Nome = "Cassa previdenza e assistenza geometri" },
                    new TipoCassa { Codice = "TC04", Nome = "Cassa nazionale previdenza e assistenza ingegneri e architetti liberi professionisti" },
                    new TipoCassa { Codice = "TC05", Nome = "Cassa nazionale del notariato" },
                    new TipoCassa { Codice = "TC06", Nome = "Cassa nazionale previdenza e assistenza ragionieri e periti commerciali" },
                    new TipoCassa { Codice = "TC07", Nome = "Ente nazionale assistenza agenti e rappresentanti di commercio (ENASARCO)" },
                    new TipoCassa { Codice = "TC08", Nome = "Ente nazionale previdenza e assistenza consulenti del lavoro (ENPACL)" },
                    new TipoCassa { Codice = "TC09", Nome = "Ente nazionale previdenza e assistenza medici (ENPAM)" },
                    new TipoCassa { Codice = "TC10", Nome = "Ente nazionale previdenza e assistenza farmacisti (ENPAF)" },
                    new TipoCassa { Codice = "TC11", Nome = "Ente nazionale previdenza e assistenza veterinari (ENPAV)" },
                    new TipoCassa { Codice = "TC12", Nome = "Ente nazionale previdenza e assistenza impiegati dell'agricoltura (ENPAIA)" },
                    new TipoCassa { Codice = "TC13", Nome = "Fondo previdenza impiegati imprese di spedizione e agenzie marittime" },
                    new TipoCassa { Codice = "TC14", Nome = "Istituto nazionale previdenza giornalisti italiani (INPGI)" },
                    new TipoCassa { Codice = "TC15", Nome = "Opera nazionale assistenza orfani sanitari italiani (ONAOSI)" },
                    new TipoCassa { Codice = "TC16", Nome = "Cassa autonoma assistenza integrativa giornalisti italiani (CASAGIT)" },
                    new TipoCassa { Codice = "TC17", Nome = "Ente previdenza periti industriali e periti industriali laureati (EPPI)" },
                    new TipoCassa { Codice = "TC18", Nome = "Ente previdenza e assistenza pluricategoriale (EPAP)" },
                    new TipoCassa { Codice = "TC19", Nome = "Ente nazionale previdenza e assistenza biologi (ENPAB)" },
                    new TipoCassa { Codice = "TC20", Nome = "Ente nazionale previdenza e assistenza professione infermieristica (ENPAPI)" },
                    new TipoCassa { Codice = "TC21", Nome = "Ente nazionale previdenza e assistenza psicologi (ENPAP)" },
                    new TipoCassa { Codice = "TC22", Nome = "INPS" }
                };
            } 
        }
    }
    
    public class TipoCassaV2 : TabellaV2<TipoCassaV2>
    {
        protected override ResourceManager ResourceManager => Resources.TipoCassa.ResourceManager;
    }
}