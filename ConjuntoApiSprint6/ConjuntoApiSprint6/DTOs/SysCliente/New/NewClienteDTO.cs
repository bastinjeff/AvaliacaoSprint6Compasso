using ConjuntoApiSprint6.Models.SysCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.DTOs.SysCliente.New
{
	public class NewClienteDTO
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public List<NewEnderecoDTO> Enderecos { get; set; }
	}
}
