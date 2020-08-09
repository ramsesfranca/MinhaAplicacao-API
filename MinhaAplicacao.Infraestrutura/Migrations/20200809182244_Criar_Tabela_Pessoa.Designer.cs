﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhaAplicacao.Infraestrutura;

namespace MinhaAplicacao.Infraestrutura.Migrations
{
    [DbContext(typeof(MinhaAplicacaoDbContext))]
    [Migration("20200809182244_Criar_Tabela_Pessoa")]
    partial class Criar_Tabela_Pessoa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MinhaAplicacao.Dominio.Entidades.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataHoraModificado")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalidade")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Naturalidade")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
