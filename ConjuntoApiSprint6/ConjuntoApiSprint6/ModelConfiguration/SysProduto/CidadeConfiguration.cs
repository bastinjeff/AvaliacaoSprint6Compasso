using ConjuntoApiSprint6.Models.SysProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.ModelConfiguration.SysProduto
{
	public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
	{
		public void Configure(EntityTypeBuilder<Cidade> builder)
		{
			builder
				.ToTable("Cidade");

			builder
				.Property(C => C.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.IsRequired();

			builder
				.Property(C => C.cidade)
				.HasColumnName("Cidade")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder.Property<Guid>("EstadoId").IsRequired();

			builder
				.HasOne(C => C.estado)
				.WithMany(E => E.Cidades)
				.HasForeignKey("EstadoId")
				.IsRequired();
		}
	}
}
