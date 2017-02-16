using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FatturaElettronicaValidator : BaseClass<FatturaElettronica.FatturaElettronica, FatturaElettronica.Validators.FatturaElettronicaValidator>
    {
        [TestInitialize]
        public new void Init() 
        {
            validator = new FatturaElettronica.Validators.FatturaElettronicaValidator();
            challenge = FatturaElettronica.FatturaElettronica.CreateInstance(FatturaElettronica.Impostazioni.Instance.PubblicaAmministrazione);
        }

       [TestMethod]
       public void FatturaElettronicaHeaderHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaHeader, typeof(FatturaElettronica.Validators.FatturaElettronicaHeaderValidator));
        }
       [TestMethod]
       public void FatturaElettronicaBodyHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaBody, typeof(FatturaElettronica.Validators.FatturaElettronicaBodyValidator));
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
