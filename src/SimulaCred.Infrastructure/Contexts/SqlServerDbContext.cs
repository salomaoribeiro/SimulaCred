using Microsoft.EntityFrameworkCore;
using SimulaCred.Domain.Entities;
using SimulaCred.Domain.Entities.Enums;

namespace SimulaCred.Infrastructure.Contexts;

public class SqlServerDbContext: DbContext
{
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProdutoInvestimento>()
            .Property(p => p.Tipo)
            .HasConversion(
                v => v.ToString(),
                v => (ProdutoInvestimentoTipo)Enum.Parse(typeof(ProdutoInvestimentoTipo), v)
            );
        
        modelBuilder.Entity<ProdutoInvestimento>()
            .Property(p => p.Risco)
            .HasConversion(
                v => v.ToString(),
                v => (ProdutoInvestimentoRisco)Enum.Parse(typeof(ProdutoInvestimentoRisco), v)
            );
        
        modelBuilder.Entity<ProdutoInvestimento>().HasData(
            new ProdutoInvestimento ( nome: "Poupança Fácil Caixa", tipo: ProdutoInvestimentoTipo.Poupanca, rentabilidade: 0.05M, risco: ProdutoInvestimentoRisco.MuitoBaixo){Id = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new ProdutoInvestimento ( nome: "CDB Caixa 2026", tipo: ProdutoInvestimentoTipo.Cdb, rentabilidade: 0.06M, risco: ProdutoInvestimentoRisco.MuitoBaixo) {Id = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new ProdutoInvestimento ( nome: "LCI Shopping Dia e Noite", tipo: ProdutoInvestimentoTipo.Lci, rentabilidade: 0.10M, risco: ProdutoInvestimentoRisco.Baixo) {Id = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new ProdutoInvestimento ( nome: "LCA Comida na Mesa", tipo: ProdutoInvestimentoTipo.Lca, rentabilidade: 0.12M, risco: ProdutoInvestimentoRisco.Baixo) {Id = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new ProdutoInvestimento ( nome: "Imovel Legal Caixa", tipo: ProdutoInvestimentoTipo.Imoveis, rentabilidade: 0.13M, risco: ProdutoInvestimentoRisco.Moderado) {Id = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new ProdutoInvestimento ( nome: "Fundo XPTO", tipo: ProdutoInvestimentoTipo.Fundo, rentabilidade: 0.15M, risco: ProdutoInvestimentoRisco.Moderado) {Id = 6, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new ProdutoInvestimento ( nome: "Ações Tabajara LTDA", tipo: ProdutoInvestimentoTipo.Acoes, rentabilidade: 0.16M, risco: ProdutoInvestimentoRisco.Alto) {Id = 7, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new ProdutoInvestimento ( nome: "Tesouro Direto Caixa", tipo: ProdutoInvestimentoTipo.TesouroDireto, rentabilidade: 0.18M, risco: ProdutoInvestimentoRisco.Alto) {Id = 8, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new ProdutoInvestimento ( nome: "Banco Master CDB", tipo: ProdutoInvestimentoTipo.BancoMasterCdb, rentabilidade: 0.20M, risco: ProdutoInvestimentoRisco.Inadimplencia) {Id = 9, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new ProdutoInvestimento ( nome: "Banco Master Precatórios", tipo: ProdutoInvestimentoTipo.BancoMasterPrecatorios, rentabilidade: 0.22M, risco: ProdutoInvestimentoRisco.Inadimplencia) {Id = 10, CreatedAt = DateTime.UtcNow, UpdatedAt = null}
        );
    }
    
    DbSet<ProdutoInvestimento> ProdutoInvestimento { get; set; }
}