using FluentValidation.TestHelper;
using FatturaElettronica.FatturaElettronicaHeader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FatturaElettronicaHeaderValidator
    {
        private FatturaElettronica.Validators.FatturaElettronicaHeaderValidator validator;
        private FatturaElettronicaHeader challenge;

        [TestInitialize]
        public void Init()
        {
            validator = new FatturaElettronica.Validators.FatturaElettronicaHeaderValidator();
            challenge = new FatturaElettronicaHeader();
        }

        [TestMethod]
        public void DatiTramissioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiTrasmissione, typeof(FatturaElettronica.Validators.DatiTrasmissioneValidator));
        }
    }
}
