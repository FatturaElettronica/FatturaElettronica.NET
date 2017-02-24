using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FatturaValidator : BaseClass<FatturaElettronica.Fattura, FatturaElettronica.Validators.FatturaValidator>
    {
        [TestInitialize]
        public new void Init() 
        {
            validator = new FatturaElettronica.Validators.FatturaValidator();
            challenge = FatturaElettronica.Fattura.CreateInstance(FatturaElettronica.Impostazioni.Instance.PubblicaAmministrazione);
        }

       [TestMethod]
       public void FatturaElettronicaHeaderHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.Header, typeof(FatturaElettronica.Validators.HeaderValidator));
        }
       [TestMethod]
       public void FatturaElettronicaBodyHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.Body, typeof(FatturaElettronica.Validators.BodyValidator));
        }

        // TODO 
        //[TestMethod]
        //public void CreateInstancePubblicaAmministrazione()
        //{
        //    var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.PubblicaAmministrazione);
        //    Assert.AreEqual(FormatoTrasmissione.PubblicaAmministrazione, f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
        //}
        //[TestMethod]
        //public void CreateInstancePrivati()
        //{
        //    var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.Privati);
        //    Assert.AreEqual(FormatoTrasmissione.Privati, f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
        //    Assert.AreEqual(new string('0', 7), f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario);
        //}
    }
}
