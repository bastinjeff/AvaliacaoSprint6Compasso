using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.SysProduto
{
	public class Produto
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public double Preco { get; set; }
		public List<Cidade_Produto> cidades { get; set; }
		public List<Produto_Tag> Tags { get; set; }
		public List<Categoria> categorias { get; set; }

	}
}
