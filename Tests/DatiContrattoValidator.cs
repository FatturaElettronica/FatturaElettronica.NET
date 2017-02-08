using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiContrattoValidator: BaseDatiDocumentoValidator<DatiContratto, FatturaElettronica.Validators.DatiContrattoValidator>
    {
    }
}
