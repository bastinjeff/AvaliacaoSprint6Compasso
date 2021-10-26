using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.SysCliente
{
	public class Cliente
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public List<Endereco_Cliente> Enderecos { get; set; }
	}
}
