using ConjuntoApiSprint6.Models.SysProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.ModelConfiguration.SysProduto
{
	public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
	{
		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder
				.ToTable("Produto");
			builder
				.Property(P => P.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.IsRequired();

			builder
				.Property(P => P.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder
				.Property(P => P.Preco)
				.HasColumnName("Preco")
				.HasColumnType("float")
				.IsRequired();

			builder
				.Property(P => P.Descricao)
				.HasColumnName("Descricao")
				.HasColumnType("varchar(max)")
				.IsRequired();
		}
	}
}
