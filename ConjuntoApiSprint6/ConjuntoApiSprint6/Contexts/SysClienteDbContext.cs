using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Contexts
{
	public class SysClienteDbContext : DbContext
	{
		public SysClienteDbContext() : base()
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;" +
				"dabatase=SysClienteDb" +
				"Integrated Security=True;" +
				"Connect Timeout=5;" +
				"Encrypt=False;" +
				"TrustServerCertificate=False;" +
				"ApplicationIntent=ReadWrite;" +
				"MultiSubnetFailover=False");
		}
	}
}
