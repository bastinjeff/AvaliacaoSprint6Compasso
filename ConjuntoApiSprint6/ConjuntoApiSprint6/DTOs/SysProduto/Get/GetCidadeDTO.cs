using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.DTOs.SysProduto.Get
{
	public class GetCidadeDTO
	{
		public string cidade { get; set; }
		public GetEstadoSysProdutoDTO estado { get; set; }
	}
}
