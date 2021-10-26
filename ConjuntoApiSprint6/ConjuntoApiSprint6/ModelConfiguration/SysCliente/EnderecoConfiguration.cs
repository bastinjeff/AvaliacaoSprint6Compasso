using ConjuntoApiSprint6.Models.SysCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.ModelConfiguration.SysCliente
{
	public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
	{
		public void Configure(EntityTypeBuilder<Endereco> builder)
		{
			builder
				.ToTable("Endereco");

			builder
				.Property(E => E.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.IsRequired();

			builder
				.Property(E => E.Cidade)
				.HasColumnName("Cidade")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder
				.Property(E => E.Bairro)
				.HasColumnName("Bairro")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder
				.Property(E => E.Rua)
				.HasColumnName("Rua")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder
				.Property(E => E.Numero)
				.HasColumnName("Numero")
				.HasColumnType("varchar(10)")
				.IsRequired();

			builder
				.Property(E => E.Complemento)
				.HasColumnName("Complemento")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder
				.Property<Guid>("EstadoId").IsRequired();

			builder
				.HasOne(E => E.UF)
				.WithMany(U => U.enderecos)
				.HasForeignKey("EstadoId");
		}
	}
}
