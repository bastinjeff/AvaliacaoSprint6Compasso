using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.DTOs.SysProduto.Get
{
	public class GetProdutoDTO
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public double Preco { get; set; }
		public List<GetCidade_ProdutoDTO> cidades { get; set; }
		public List<GetProduto_TagDTO> Tags { get; set; }
		public List<GetCategoria_ProdutoDTO> categorias { get; set; }

		public bool Frete { get; set; }
	}
}
