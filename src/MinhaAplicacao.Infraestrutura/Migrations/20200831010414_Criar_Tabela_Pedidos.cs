using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MinhaAplicacao.Infraestrutura.Migrations
{
    public partial class Criar_Tabela_Pedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Pedidos",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraCadastro = table.Column<DateTime>("datetime", nullable: false),
                    DataHoraModificado = table.Column<DateTime>("datetime", nullable: true),
                    ComandaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        "FK_Pedidos_Comandas_ComandaId",
                        x => x.ComandaId,
                        "Comandas",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Pedidos_Cardapios",
                table => new
                {
                    PedidoId = table.Column<int>(nullable: false),
                    CardapioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos_Cardapios", x => new { x.PedidoId, x.CardapioId });
                    table.ForeignKey(
                        "FK_Pedidos_Cardapios_Cardapios_CardapioId",
                        x => x.CardapioId,
                        "Cardapios",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Pedidos_Cardapios_Pedidos_PedidoId",
                        x => x.PedidoId,
                        "Pedidos",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Pedidos_ComandaId",
                "Pedidos",
                "ComandaId");

            migrationBuilder.CreateIndex(
                "IX_Pedidos_Cardapios_CardapioId",
                "Pedidos_Cardapios",
                "CardapioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Pedidos_Cardapios");

            migrationBuilder.DropTable(
                "Pedidos");
        }
    }
}
