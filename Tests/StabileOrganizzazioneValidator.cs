using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class StabileOrganizzazioneValidator 
        : BaseLocalitàValidator<FatturaElettronica.Common.StabileOrganizzazione, FatturaElettronica.Validators.StabileOrganizzazioneValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            base.Init();

            // Make sure the instance is not Empty (IsEmpty() returns false)
            challenge.NumeroCivico = "1";
        }
        [TestMethod]
        public void StabileOrganizzazioneIsNotRequiredSoLetItBeEmpty()
        {
            // For this test we want the instance to be Empty (IsEmpty() returns true)
            challenge.NumeroCivico = null;

            // When instance is Empty no validation on its properties is performed
            var r = validator.Validate(challenge);
            Assert.IsTrue(r.IsValid);
        }
    }
}
