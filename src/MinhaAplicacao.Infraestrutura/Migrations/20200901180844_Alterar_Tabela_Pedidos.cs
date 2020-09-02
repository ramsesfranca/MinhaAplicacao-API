using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhaAplicacao.Infraestrutura.Migrations
{
    public partial class Alterar_Tabela_Pedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Pedidos_Cardapios");

            migrationBuilder.AddColumn<int>(
                "CardapioId",
                "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                "IX_Pedidos_CardapioId",
                "Pedidos",
                "CardapioId");

            migrationBuilder.AddForeignKey(
                "FK_Pedidos_Cardapios_CardapioId",
                "Pedidos",
                "CardapioId",
                "Cardapios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Pedidos_Cardapios_CardapioId",
                "Pedidos");

            migrationBuilder.DropIndex(
                "IX_Pedidos_CardapioId",
                "Pedidos");

            migrationBuilder.DropColumn(
                "CardapioId",
                "Pedidos");

            migrationBuilder.CreateTable(
                "Pedidos_Cardapios",
                table => new
                {
                    PedidoId = table.Column<int>("int", nullable: false),
                    CardapioId = table.Column<int>("int", nullable: false)
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
                "IX_Pedidos_Cardapios_CardapioId",
                "Pedidos_Cardapios",
                "CardapioId");
        }
    }
}
