using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.SysCliente
{
	public class Endereco
	{
		public Guid Id { get; set; }
		public string Cidade { get; set; }
		public string Bairro { get; set; }
		public string Rua { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public Estado UF { get; set; }
		public List<Endereco_Cliente> Clientes { get; set; }
	}
}
