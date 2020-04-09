using FatturaElettronica.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Common
{
    [TestClass]
    public class IdTrasmittenteValidator
    {
        [TestMethod]
        public void IdTrasmittenteValidatorIsOfTypeIdFiscaleIVAValidator()
        {
            var challenge = new FatturaElettronica.Validators.IdTrasmittenteValidator();
            Assert.IsInstanceOfType(challenge, typeof(IdFiscaleIVAValidator));
        }
    }
}