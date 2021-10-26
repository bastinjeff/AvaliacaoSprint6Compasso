using ConjuntoApiSprint6.Models.SysProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.ModelConfiguration.SysProduto
{
	public class Cidade_ProdutoConfiguration : IEntityTypeConfiguration<Cidade_Produto>
	{
		public void Configure(EntityTypeBuilder<Cidade_Produto> builder)
		{
			builder
				.ToTable("Cidade_Produto");

			builder.Property<Guid>("CidadeId").IsRequired();
			builder.Property<Guid>("ProdutoId").IsRequired();

			builder.HasKey("CidadeId", "ProdutoId");

			builder
				.HasOne(PT => PT.produto)
				.WithMany(P => P.cidades)
				.HasForeignKey("ProdutoId")
				.IsRequired();

			builder
				.HasOne(PT => PT.cidade)
				.WithMany(C => C.produtos)
				.HasForeignKey("CidadeId")
				.IsRequired();
		}
	}
}
