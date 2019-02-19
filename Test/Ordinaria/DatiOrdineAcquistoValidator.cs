using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using Tests;

namespace Ordinaria.Tests
{
    [TestClass]
    public class DatiDocumentoValidator
        : BaseDatiDocumentoValidator<DatiOrdineAcquisto, FatturaElettronica.Validators.DatiOrdineAcquistoValidator>
    {
    }
}
