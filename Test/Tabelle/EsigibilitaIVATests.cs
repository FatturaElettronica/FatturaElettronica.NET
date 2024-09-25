using System.Linq;
using FatturaElettronica.Tabelle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Tabelle;

[TestClass]
public class EsigibilitaIVATests
{
    [TestMethod]
    public void CondizioniPagamento() => Test1<CondizioniPagamento, CondizioniPagamentoV2>();

    [TestMethod]
    public void EsigibilitaIVA() => Test1<EsigibilitaIVAV2, EsigibilitaIVAV2>();
    
    [TestMethod]
    public void SocioUnico() => Test1<SocioUnico, SocioUnicoV2>();
    
    [TestMethod]
    public void SoggettoEmittente() => Test1<SoggettoEmittente, SoggettoEmittenteV2>();
    
    [TestMethod]
    public void StatoLiquidazione() => Test1<StatoLiquidazione, StatoLiquidazioneV2>();
    
    [TestMethod]
    public void TipoCessionePrestazione() => Test1<TipoCessionePrestazione, TipoCessionePrestazioneV2>();
    
    [TestMethod]
    public void ScontoMaggiorazione() => Test1<ScontoMaggiorazione, ScontoMaggiorazioneV2>();
    
    [TestMethod]
    public void TipoDocumentoSemplificata() => Test1<TipoDocumentoSemplificata, TipoDocumentoSemplificataV2>();
    
    [TestMethod]
    public void TipoRitenuta() => Test1<TipoRitenuta, TipoRitenutaV2>();

    private void Test1<T1, T2>()
        where T1 : Tabella, new()
        where T2 : Tabella, new()
    {
        var tabellaV1 = new T1();
        var tabellaV2 = new T2();

        CollectionAssert.AreEquivalent(tabellaV1.Codici.ToArray(), tabellaV2.Codici.ToArray());
        CollectionAssert.AreEquivalent(tabellaV1.List.Select(e => e.Nome).ToArray(), tabellaV2.List.Select(e => e.Nome).ToArray());
    }
}