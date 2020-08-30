using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MinhaAplicacao.Infraestrutura.Migrations
{
    public partial class Criar_Tabela_Cardapios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Cardapios",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraCadastro = table.Column<DateTime>("datetime", nullable: false),
                    DataHoraModificado = table.Column<DateTime>("datetime", nullable: true),
                    Nome = table.Column<string>("varchar(80)", nullable: false),
                    Preco = table.Column<decimal>("decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Cardapios");
        }
    }
}
