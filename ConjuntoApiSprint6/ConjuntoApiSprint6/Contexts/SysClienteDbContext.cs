using ConjuntoApiSprint6.ModelConfiguration.SysCliente;
using ConjuntoApiSprint6.Models.SysCliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Contexts
{
	public class SysClienteDbContext : DbContext
	{

		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Estado> Estados { get; set; }

		public SysClienteDbContext(DbContextOptions<SysClienteDbContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ClienteConfiguration());
			modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
			modelBuilder.ApplyConfiguration(new EstadoConfiguration());
		}
	}
}
