using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MinhaAplicacao.Infraestrutura.Migrations
{
    public partial class Criar_Tabela_Comandas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Comandas",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraCadastro = table.Column<DateTime>("datetime", nullable: false),
                    DataHoraModificado = table.Column<DateTime>("datetime", nullable: true),
                    Codigo = table.Column<string>("varchar(20)", nullable: false),
                    StatusComanda = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Comandas");
        }
    }
}
