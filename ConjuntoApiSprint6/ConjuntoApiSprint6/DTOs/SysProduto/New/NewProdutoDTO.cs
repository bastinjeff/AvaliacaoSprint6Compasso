using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.DTOs.SysProduto.New
{
	public class NewProdutoDTO
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public double Preco { get; set; }
		public List<NewCidade_ProdutoDTO> cidades { get; set; }
		public List<NewProduto_TagDTO> Tags { get; set; }
		public List<NewCategoria_ProdutoDTO> categorias { get; set; }
	}
}
