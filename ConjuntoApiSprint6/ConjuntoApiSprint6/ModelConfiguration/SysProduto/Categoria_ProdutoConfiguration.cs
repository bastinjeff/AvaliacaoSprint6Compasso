using ConjuntoApiSprint6.Models.SysProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.ModelConfiguration.SysProduto
{
	public class Categoria_ProdutoConfiguration : IEntityTypeConfiguration<Categoria_Produto>
	{
		public void Configure(EntityTypeBuilder<Categoria_Produto> builder)
		{
			builder
				.ToTable("Categoria_Produto");

			builder.Property<Guid>("CategoriaId").IsRequired();
			builder.Property<Guid>("ProdutoId").IsRequired();

			builder.HasKey("CategoriaId", "ProdutoId");

			builder
				.HasOne(PT => PT.produto)
				.WithMany(P => P.categorias)
				.HasForeignKey("ProdutoId")
				.IsRequired();

			builder
				.HasOne(PT => PT.categoria)
				.WithMany(T => T.Produtos)
				.HasForeignKey("CategoriaId")
				.IsRequired();
		}
	}
}
