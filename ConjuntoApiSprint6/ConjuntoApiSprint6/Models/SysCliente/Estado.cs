using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.SysCliente
{
	public class Estado
	{
		public Guid Id { get; set; }
		public string UF { get; set; }

		public List<Endereco> enderecos { get; set; }
	}
}
