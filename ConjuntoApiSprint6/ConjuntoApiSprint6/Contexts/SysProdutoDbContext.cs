using ConjuntoApiSprint6.ModelConfiguration.SysProduto;
using ConjuntoApiSprint6.Models.SysProduto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Contexts
{
	public class SysProdutoDbContext : DbContext
	{
		public DbSet<Categoria>	Categorias { get; set; }
		public DbSet<Categoria_Produto> Categoria_Produtos { get; set; }
		public DbSet<Cidade> Cidades { get; set; }
		public DbSet<Cidade_Produto> Cidade_Produtos { get; set; }
		public DbSet<Estado> Estados { get; set; }
		public DbSet<LoginTable> LoginTables { get; set; }
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Produto_Tag> Produto_Tags { get; set; }
		public DbSet<Tag> Tags { get; set; }		

		public SysProdutoDbContext(DbContextOptions<SysProdutoDbContext> options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
			modelBuilder.ApplyConfiguration(new Categoria_ProdutoConfiguration());
			modelBuilder.ApplyConfiguration(new CidadeConfiguration());
			modelBuilder.ApplyConfiguration(new Cidade_ProdutoConfiguration());
			modelBuilder.ApplyConfiguration(new EstadoConfiguration());
			modelBuilder.ApplyConfiguration(new LoginTableConfiguration());
			modelBuilder.ApplyConfiguration(new Produto_TagConfiguration());
			modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
			modelBuilder.ApplyConfiguration(new TagConfiguration());
		}
	}
}
