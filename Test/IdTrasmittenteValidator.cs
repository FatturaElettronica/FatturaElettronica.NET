using FatturaElettronica.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
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
