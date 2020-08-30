using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MinhaAplicacao.Infraestrutura.Migrations
{
    public partial class Criar_Tabela_Pessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Pessoas",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraCadastro = table.Column<DateTime>("datetime", nullable: false),
                    DataHoraModificado = table.Column<DateTime>("datetime", nullable: true),
                    Nome = table.Column<string>("varchar(80)", nullable: false),
                    Sexo = table.Column<int>(nullable: true),
                    Email = table.Column<string>("varchar(80)", nullable: true),
                    DataNascimento = table.Column<DateTime>("datetime", nullable: false),
                    Naturalidade = table.Column<string>("varchar(80)", nullable: true),
                    Nacionalidade = table.Column<string>("varchar(80)", nullable: true),
                    CPF = table.Column<string>("varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Pessoas");
        }
    }
}
