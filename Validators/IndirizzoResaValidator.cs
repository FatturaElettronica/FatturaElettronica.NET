using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class IndirizzoResaValidator : LocalitàBaseValidator<IndirizzoResa>
    {
        public IndirizzoResaValidator() : base(optional:true) { }
    }
}
