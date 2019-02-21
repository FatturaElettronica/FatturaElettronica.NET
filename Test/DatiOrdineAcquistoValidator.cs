using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiDocumentoValidator
        : BaseDatiDocumentoValidator<DatiOrdineAcquisto, FatturaElettronica.Validators.DatiOrdineAcquistoValidator>
    {
    }
}
