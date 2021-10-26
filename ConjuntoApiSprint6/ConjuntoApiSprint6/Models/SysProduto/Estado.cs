using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.SysProduto
{
	public class Estado
	{
		public Guid Id { get; set; }
		public string UF { get; set; }
		public List<Cidade> Cidades { get; set; }
	}
}
