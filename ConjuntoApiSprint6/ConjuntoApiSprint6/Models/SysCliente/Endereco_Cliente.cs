using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.SysCliente
{
	public class Endereco_Cliente
	{
		public bool Principal { get; set; }
		public Endereco endereco { get; set; }
		public Cliente cliente { get; set; }
	}
}
