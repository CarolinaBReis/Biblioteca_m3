﻿// <auto-generated />
using System;
using API_Biblioteca_TrabalhoFinal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Biblioteca_TrabalhoFinal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220703191748_CreateDB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_Biblioteca_TrabalhoFinal.Models.Leitores", b =>
                {
                    b.Property<int>("NIF")
                        .HasColumnType("int");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEstado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRegisto")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoRegisto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIF");

                    b.ToTable("Leitores");
                });

            modelBuilder.Entity("API_Biblioteca_TrabalhoFinal.Models.Nucleos", b =>
                {
                    b.Property<int>("IDNucleo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNucleo"), 1L, 1);

                    b.Property<string>("Nucleo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNucleo");

                    b.ToTable("Nucleos");
                });

            modelBuilder.Entity("API_Biblioteca_TrabalhoFinal.Models.Obras", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Capa")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ISBN");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("API_Biblioteca_TrabalhoFinal.Models.Obras_Nucleos", b =>
                {
                    b.Property<int>("IDNucleo")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Disponivel")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int?>("Requisitado")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("IDNucleo", "ISBN");

                    b.ToTable("Obras_Nucleos");
                });

            modelBuilder.Entity("API_Biblioteca_TrabalhoFinal.Models.Requisicoes", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IDNucleo")
                        .HasColumnType("int");

                    b.Property<int>("NIF")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataRequisicao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.HasKey("ISBN", "IDNucleo", "NIF", "DataRequisicao");

                    b.ToTable("Requisicoes");
                });
#pragma warning restore 612, 618
        }
    }
}
