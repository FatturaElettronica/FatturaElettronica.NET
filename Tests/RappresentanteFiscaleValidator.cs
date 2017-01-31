using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.RappresentanteFiscale;

namespace Tests
{
    [TestClass]
    public class RappresentanteFiscaleValidator : 
        BaseRappresentanteFiscaleValidator<RappresentanteFiscale, FatturaElettronica.Validators.RappresentanteFiscaleValidator>
    {
    }
}
