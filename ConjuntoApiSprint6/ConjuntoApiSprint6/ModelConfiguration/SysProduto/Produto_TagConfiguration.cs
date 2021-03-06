using ConjuntoApiSprint6.Models.SysProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.ModelConfiguration.SysProduto
{
	public class Produto_TagConfiguration : IEntityTypeConfiguration<Produto_Tag>
	{
		public void Configure(EntityTypeBuilder<Produto_Tag> builder)
		{
			builder
				.ToTable("Produto_Tag");

			builder.Property<Guid>("TagId").IsRequired();
			builder.Property<Guid>("ProdutoId").IsRequired();

			builder.HasKey("TagId", "ProdutoId");

			builder
				.HasOne(PT => PT.produto)
				.WithMany(P => P.Tags)
				.HasForeignKey("ProdutoId")
				.IsRequired();

			builder
				.HasOne(PT => PT.tag)
				.WithMany(T => T.Produtos)
				.HasForeignKey("TagId")
				.IsRequired();
		}
	}
}

