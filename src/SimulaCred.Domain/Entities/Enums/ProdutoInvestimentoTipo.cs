namespace SimulaCred.Domain.Entities.Enums;

public enum ProdutoInvestimentoTipo
{
    Poupanca,               // muito baixo
    Cdb,                    // muito baixo
    Lci,                    // baixo
    Lca,                    // baixo
    Imoveis,                // moderado
    Fundo,                  // moderado
    Acoes,                  // alto
    TesouroDireto,          // alto
    BancoMasterCdb,         // inadimplente
    BancoMasterPrecatorios  // inadimplente
}