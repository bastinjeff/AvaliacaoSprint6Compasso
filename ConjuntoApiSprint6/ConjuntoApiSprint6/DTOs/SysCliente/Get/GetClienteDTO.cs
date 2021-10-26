using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.DTOs.SysCliente.Get
{
	public class GetClienteDTO
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public List<GetEnderecoDTO> Enderecos { get; set; }
	}
}
