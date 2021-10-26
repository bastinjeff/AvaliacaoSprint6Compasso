using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.SysProduto
{
	public class LoginTable
	{
		public Guid Id { get; set; }
		public string Login { get; set; }
		public string Senha { get; set; }
	}
}
