﻿// <auto-generated />
using System;
using ConjuntoApiSprint6.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConjuntoApiSprint6.Migrations
{
    [DbContext(typeof(SysClienteDbContext))]
    partial class SysClienteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConjuntoApiSprint6.Models.SysCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CPF");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ConjuntoApiSprint6.Models.SysCliente.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Bairro");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Cidade");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Complemento");

                    b.Property<Guid>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Numero");

                    b.Property<bool>("Principal")
                        .HasColumnType("bit")
                        .HasColumnName("Principal");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Rua");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ConjuntoApiSprint6.Models.SysCliente.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("ConjuntoApiSprint6.Models.SysCliente.Endereco", b =>
                {
                    b.HasOne("ConjuntoApiSprint6.Models.SysCliente.Cliente", "cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConjuntoApiSprint6.Models.SysCliente.Estado", "UF")
                        .WithMany("enderecos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("UF");
                });

            modelBuilder.Entity("ConjuntoApiSprint6.Models.SysCliente.Cliente", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("ConjuntoApiSprint6.Models.SysCliente.Estado", b =>
                {
                    b.Navigation("enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
