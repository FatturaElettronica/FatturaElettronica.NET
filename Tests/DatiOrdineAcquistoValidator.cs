using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiDocumentoValidator
        : BaseDatiDocumentoValidator<DatiOrdineAcquisto, FatturaElettronica.Validators.DatiOrdineAcquistoValidator>
    {
    }
}
