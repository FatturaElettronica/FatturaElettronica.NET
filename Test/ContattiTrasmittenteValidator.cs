namespace Tests
{
    using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.DatiTrasmissione;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContattiTrasmittenteValidator
        : BaseClass<ContattiTrasmittente, FatturaElettronica.Validators.ContattiTrasmittenteValidator>
    {
        [TestMethod]
        public void TelefonoIsOptional()
        {
            AssertOptional(x => x.Telefono);
        }
        [TestMethod]
        public void TelefonoMinMaxLength()
        {
            AssertMinMaxLength(x => x.Telefono, 5, 12);
        }
        [TestMethod]
        public void EmailIsOptional()
        {
            AssertOptional(x => x.Email);
        }
        [TestMethod]
        public void EmailMinMaxLength()
        {
            AssertMinMaxLength(x => x.Email, 7, 256);
        }
    }
}
