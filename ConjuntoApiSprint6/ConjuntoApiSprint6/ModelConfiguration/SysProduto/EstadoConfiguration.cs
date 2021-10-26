using ConjuntoApiSprint6.Models.SysProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.ModelConfiguration.SysProduto
{
	public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
	{
		public void Configure(EntityTypeBuilder<Estado> builder)
		{
			builder
				.ToTable("Estado");

			builder
				.Property(E => E.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.IsRequired();

			builder
				.Property(E => E.UF)
				.HasColumnName("UF")
				.HasColumnType("char(2)")
				.IsRequired();
		}
	}
}
