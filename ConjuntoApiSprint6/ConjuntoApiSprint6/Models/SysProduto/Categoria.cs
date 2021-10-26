using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.SysProduto
{
	public class Categoria
	{
		public Guid Id { get; set; }
		public string categoria { get; set; }
		public List<Categoria_Produto> Produtos { get; set; }
	}
}
