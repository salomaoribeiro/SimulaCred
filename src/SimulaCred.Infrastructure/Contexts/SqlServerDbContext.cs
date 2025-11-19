using Microsoft.EntityFrameworkCore;
using SimulaCred.Domain.Entities;
using SimulaCred.Domain.Entities.Enums;

namespace SimulaCred.Infrastructure.Contexts;

public class SqlServerDbContext : DbContext
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
            new ProdutoInvestimento(nome: "Poupança Fácil Caixa", tipo: ProdutoInvestimentoTipo.Poupanca, rentabilidade: 0.05M, risco: ProdutoInvestimentoRisco.MuitoBaixo, prazoMinimo: 1, prazoMaximo: 6) { Id = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProdutoInvestimento(nome: "CDB Caixa 2026", tipo: ProdutoInvestimentoTipo.Cdb, rentabilidade: 0.06M, risco: ProdutoInvestimentoRisco.MuitoBaixo, prazoMinimo: 7, prazoMaximo: 12) { Id = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProdutoInvestimento(nome: "LCI Shopping Dia e Noite", tipo: ProdutoInvestimentoTipo.Lci, rentabilidade: 0.10M, risco: ProdutoInvestimentoRisco.Baixo, prazoMinimo: 1, prazoMaximo: 12) { Id = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProdutoInvestimento(nome: "LCA Comida na Mesa", tipo: ProdutoInvestimentoTipo.Lca, rentabilidade: 0.12M, risco: ProdutoInvestimentoRisco.Baixo, prazoMinimo: 13, prazoMaximo: 24) { Id = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProdutoInvestimento(nome: "Imovel Legal Caixa", tipo: ProdutoInvestimentoTipo.Imoveis, rentabilidade: 0.13M, risco: ProdutoInvestimentoRisco.Moderado, prazoMinimo: 24, prazoMaximo: 60) { Id = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProdutoInvestimento(nome: "Fundo XPTO", tipo: ProdutoInvestimentoTipo.Fundo, rentabilidade: 0.15M, risco: ProdutoInvestimentoRisco.Moderado, prazoMinimo: 12, prazoMaximo: 48) { Id = 6, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProdutoInvestimento(nome: "Ações Tabajara LTDA", tipo: ProdutoInvestimentoTipo.Acoes, rentabilidade: 0.16M, risco: ProdutoInvestimentoRisco.Alto, prazoMinimo: 1, prazoMaximo: null) { Id = 7, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProdutoInvestimento(nome: "Tesouro Direto Caixa", tipo: ProdutoInvestimentoTipo.TesouroDireto, rentabilidade: 0.18M, risco: ProdutoInvestimentoRisco.Alto, prazoMinimo: 12, prazoMaximo: 36) { Id = 8, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProdutoInvestimento(nome: "Banco Master CDB", tipo: ProdutoInvestimentoTipo.BancoMasterCdb, rentabilidade: 0.20M, risco: ProdutoInvestimentoRisco.Inadimplencia, prazoMinimo: 1, prazoMaximo: 12) { Id = 9, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProdutoInvestimento(nome: "Banco Master Precatórios", tipo: ProdutoInvestimentoTipo.BancoMasterPrecatorios, rentabilidade: 0.22M, risco: ProdutoInvestimentoRisco.Inadimplencia, prazoMinimo: 13, prazoMaximo: 24) { Id = 10, CreatedAt = DateTime.UtcNow, UpdatedAt = null }
        );
    }

    public DbSet<ProdutoInvestimento> Produtos { get; set; }
    public DbSet<Simulacao> Simulacoes { get; set; }
}
