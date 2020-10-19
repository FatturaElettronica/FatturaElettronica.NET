using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiConvenzioneValidator
        : BaseDatiDocumentoValidator<DatiConvenzione, FatturaElettronica.Validators.DatiConvenzioneValidator>
    {
    }
}
