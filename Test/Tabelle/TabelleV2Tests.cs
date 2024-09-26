using System.Linq;
using FatturaElettronica.Tabelle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Tabelle;

[TestClass]
public class TabelleV2Tests
{
    [TestMethod]
    public void CondizioniPagamento() => CoreTest<CondizioniPagamento, CondizioniPagamentoV2>();

    [TestMethod]
    public void EsigibilitaIVA() => CoreTest<EsigibilitaIVAV2, EsigibilitaIVAV2>();
    
    [TestMethod]
    public void SocioUnico() => CoreTest<SocioUnico, SocioUnicoV2>();
    
    [TestMethod]
    public void SoggettoEmittente() => CoreTest<SoggettoEmittente, SoggettoEmittenteV2>();
    
    [TestMethod]
    public void StatoLiquidazione() => CoreTest<StatoLiquidazione, StatoLiquidazioneV2>();
    
    [TestMethod]
    public void TipoCessionePrestazione() => CoreTest<TipoCessionePrestazione, TipoCessionePrestazioneV2>();
    
    [TestMethod]
    public void ScontoMaggiorazione() => CoreTest<ScontoMaggiorazione, ScontoMaggiorazioneV2>();
    
    [TestMethod]
    public void TipoDocumentoSemplificata() => CoreTest<TipoDocumentoSemplificata, TipoDocumentoSemplificataV2>();
    
    [TestMethod]
    public void TipoRitenuta() => CoreTest<TipoRitenuta, TipoRitenutaV2>();
    
    [TestMethod]
    public void TipoResa() => CoreTest<TipoResa, TipoResaV2>();
    
    [TestMethod]
    public void TipoDocumento() => CoreTest<TipoDocumento, TipoDocumentoV2>();
    
    [TestMethod]
    public void TipoCassa() => CoreTest<TipoCassa, TipoCassaV2>();
    
    [TestMethod]
    public void RegimeFiscale() => CoreTest<RegimeFiscale, RegimeFiscaleV2>();
    
    [TestMethod]
    public void NaturaSemplificata() => CoreTest<NaturaSemplificata, NaturaSemplificataV2>();
    
    [TestMethod]
    public void Natura() => CoreTest<Natura, NaturaV2>();
    
    [TestMethod]    
    public void ModalitaPagamento() => CoreTest<ModalitaPagamento, ModalitaPagamentoV2>();
    
    [TestMethod]
    public void CausalePagamento() => CoreTest<CausalePagamento, CausalePagamentoV2>();
    
    [TestMethod]
    public void IdPaese() => CoreTest<IdPaese, IdPaeseV2>();
    
    [TestMethod]
    public void Divisa() => CoreTest<Divisa, DivisaV2>();
    

    private void CoreTest<T1, T2>()
        where T1 : Tabella, new()
        where T2 : Tabella, new()
    {
        var tabellaV1 = new T1();
        var tabellaV2 = new T2();

        var s = tabellaV1.Codici.ToList().Except(tabellaV2.Codici.ToList());
        var ss = tabellaV1.List.Select(e => e.Codice).GroupBy(e => e, (s1, enumerable) => new {e = s1, e1 = enumerable.Count()}).OrderByDescending(e => e.e1).ToList();

        CollectionAssert.AreEquivalent(tabellaV1.List.Select(e => e.Descrizione).ToArray(), tabellaV2.List.Select(e => e.Descrizione).ToArray());
    }
}