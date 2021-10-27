using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.DTOs.SysProduto.Update
{
	public class UpdateProdutoDTO
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public double Preco { get; set; }
		public List<UpdateCidade_ProdutoDTO> cidades { get; set; }
		public List<UpdateProduto_TagDTO> Tags { get; set; }
		public List<UpdateCategoria_ProdutoDTO> categorias { get; set; }
	}
}
