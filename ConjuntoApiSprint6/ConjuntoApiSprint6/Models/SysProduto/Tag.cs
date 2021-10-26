using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.SysProduto
{
	public class Tag
	{
		public Guid Id { get; set; }
		public string tag { get; set; }
		public List<Produto_Tag> Produtos { get; set; }
	}
}
