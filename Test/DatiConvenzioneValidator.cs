using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiConvenzioneValidator
        : BaseDatiDocumentoValidator<DatiConvenzione, FatturaElettronica.Validators.DatiConvenzioneValidator>
    {
    }
}
