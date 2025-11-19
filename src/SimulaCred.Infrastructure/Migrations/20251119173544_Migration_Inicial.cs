using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimulaCred.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration_Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rentabilidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Risco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrazoMinimo = table.Column<short>(type: "smallint", nullable: false),
                    PrazoMaximo = table.Column<short>(type: "smallint", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    ValorInvestido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrazoInvestimento = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Simulacoes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ativo", "CreatedAt", "Nome", "PrazoMaximo", "PrazoMinimo", "Rentabilidade", "Risco", "Tipo", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 11, 19, 17, 35, 44, 179, DateTimeKind.Utc).AddTicks(8220), "Poupança Fácil Caixa", (short)6, (short)1, 0.05m, "MuitoBaixo", "Poupanca", null },
                    { 2, true, new DateTime(2025, 11, 19, 17, 35, 44, 179, DateTimeKind.Utc).AddTicks(8220), "CDB Caixa 2026", (short)12, (short)7, 0.06m, "MuitoBaixo", "Cdb", null },
                    { 3, true, new DateTime(2025, 11, 19, 17, 35, 44, 179, DateTimeKind.Utc).AddTicks(8220), "LCI Shopping Dia e Noite", (short)12, (short)1, 0.10m, "Baixo", "Lci", null },
                    { 4, true, new DateTime(2025, 11, 19, 17, 35, 44, 179, DateTimeKind.Utc).AddTicks(8220), "LCA Comida na Mesa", (short)24, (short)13, 0.12m, "Baixo", "Lca", null },
                    { 5, true, new DateTime(2025, 11, 19, 17, 35, 44, 179, DateTimeKind.Utc).AddTicks(8220), "Imovel Legal Caixa", (short)60, (short)24, 0.13m, "Moderado", "Imoveis", null },
                    { 6, true, new DateTime(2025, 11, 19, 17, 35, 44, 179, DateTimeKind.Utc).AddTicks(8230), "Fundo XPTO", (short)48, (short)12, 0.15m, "Moderado", "Fundo", null },
                    { 7, true, new DateTime(2025, 11, 19, 17, 35, 44, 179, DateTimeKind.Utc).AddTicks(8230), "Ações Tabajara LTDA", null, (short)1, 0.16m, "Alto", "Acoes", null },
                    { 8, true, new DateTime(2025, 11, 19, 17, 35, 44, 179, DateTimeKind.Utc).AddTicks(8230), "Tesouro Direto Caixa", (short)36, (short)12, 0.18m, "Alto", "TesouroDireto", null },
                    { 9, true, new DateTime(2025, 11, 19, 17, 35, 44, 179, DateTimeKind.Utc).AddTicks(8230), "Banco Master CDB", (short)12, (short)1, 0.20m, "Inadimplencia", "BancoMasterCdb", null },
                    { 10, true, new DateTime(2025, 11, 19, 17, 35, 44, 179, DateTimeKind.Utc).AddTicks(8230), "Banco Master Precatórios", (short)24, (short)13, 0.22m, "Inadimplencia", "BancoMasterPrecatorios", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Simulacoes_ProdutoId",
                table: "Simulacoes",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Simulacoes");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
