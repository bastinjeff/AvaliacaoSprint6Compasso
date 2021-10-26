using ConjuntoApiSprint6.Models.SysCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.ModelConfiguration.SysCliente
{
	public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder
				.ToTable("Cliente");

			builder
				.Property(C => C.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.IsRequired();
				

			builder
				.Property(C => C.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(max)")
				.IsRequired();
			builder
				.Property(C => C.CPF)
				.HasColumnName("CPF")
				.HasColumnType("varchar(20)")
				.IsRequired();
				
		}
	}
}
