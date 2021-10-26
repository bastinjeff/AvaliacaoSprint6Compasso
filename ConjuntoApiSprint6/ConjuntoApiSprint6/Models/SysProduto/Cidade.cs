using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.SysProduto
{
	public class Cidade
	{
		public Guid Id { get; set; }
		public string cidade { get; set; }
		public Estado estado { get; set; }
		public Cidade_Produto produtos { get; set; }
	}
}
