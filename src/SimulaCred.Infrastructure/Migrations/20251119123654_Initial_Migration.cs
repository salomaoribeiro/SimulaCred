using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimulaCred.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutoInvestimento",
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
                    table.PrimaryKey("PK_ProdutoInvestimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulacao",
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
                    table.PrimaryKey("PK_Simulacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Simulacao_ProdutoInvestimento_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "ProdutoInvestimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProdutoInvestimento",
                columns: new[] { "Id", "Ativo", "CreatedAt", "Nome", "PrazoMaximo", "PrazoMinimo", "Rentabilidade", "Risco", "Tipo", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 11, 19, 12, 36, 54, 367, DateTimeKind.Utc).AddTicks(3180), "Poupança Fácil Caixa", (short)6, (short)1, 0.05m, "MuitoBaixo", "Poupanca", null },
                    { 2, true, new DateTime(2025, 11, 19, 12, 36, 54, 367, DateTimeKind.Utc).AddTicks(3180), "CDB Caixa 2026", (short)12, (short)7, 0.06m, "MuitoBaixo", "Cdb", null },
                    { 3, true, new DateTime(2025, 11, 19, 12, 36, 54, 367, DateTimeKind.Utc).AddTicks(3180), "LCI Shopping Dia e Noite", (short)12, (short)1, 0.10m, "Baixo", "Lci", null },
                    { 4, true, new DateTime(2025, 11, 19, 12, 36, 54, 367, DateTimeKind.Utc).AddTicks(3180), "LCA Comida na Mesa", (short)24, (short)13, 0.12m, "Baixo", "Lca", null },
                    { 5, true, new DateTime(2025, 11, 19, 12, 36, 54, 367, DateTimeKind.Utc).AddTicks(3180), "Imovel Legal Caixa", (short)60, (short)24, 0.13m, "Moderado", "Imoveis", null },
                    { 6, true, new DateTime(2025, 11, 19, 12, 36, 54, 367, DateTimeKind.Utc).AddTicks(3190), "Fundo XPTO", (short)48, (short)12, 0.15m, "Moderado", "Fundo", null },
                    { 7, true, new DateTime(2025, 11, 19, 12, 36, 54, 367, DateTimeKind.Utc).AddTicks(3190), "Ações Tabajara LTDA", null, (short)1, 0.16m, "Alto", "Acoes", null },
                    { 8, true, new DateTime(2025, 11, 19, 12, 36, 54, 367, DateTimeKind.Utc).AddTicks(3190), "Tesouro Direto Caixa", (short)36, (short)12, 0.18m, "Alto", "TesouroDireto", null },
                    { 9, true, new DateTime(2025, 11, 19, 12, 36, 54, 367, DateTimeKind.Utc).AddTicks(3190), "Banco Master CDB", (short)12, (short)1, 0.20m, "Inadimplencia", "BancoMasterCdb", null },
                    { 10, true, new DateTime(2025, 11, 19, 12, 36, 54, 367, DateTimeKind.Utc).AddTicks(3190), "Banco Master Precatórios", (short)24, (short)13, 0.22m, "Inadimplencia", "BancoMasterPrecatorios", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Simulacao_ProdutoId",
                table: "Simulacao",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Simulacao");

            migrationBuilder.DropTable(
                name: "ProdutoInvestimento");
        }
    }
}
