using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.DTOs.SysCliente.Update
{
	public class UpdateEnderecoDTO
	{
		public string Cidade { get; set; }
		public string Bairro { get; set; }
		public string Rua { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public bool Principal { get; set; }
		public UpdateEstadoDTO UF { get; set; }
	}
}
