using ConjuntoApiSprint6.Models.SysProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.ModelConfiguration.SysProduto
{
	public class LoginTableConfiguration : IEntityTypeConfiguration<LoginTable>
	{
		public void Configure(EntityTypeBuilder<LoginTable> builder)
		{
			builder
				.ToTable("LoginTable");

			builder
				.Property(LT => LT.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.IsRequired();

			builder
				.Property(LT => LT.Login)
				.HasColumnName("Login")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder
				.Property(LT => LT.Senha)
				.HasColumnName("Senha")
				.HasColumnType("varchar(max)")
				.IsRequired();
		}
	}
}
