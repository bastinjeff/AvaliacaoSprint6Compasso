using ConjuntoApiSprint6.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.Auditoria
{
	public class UserAccess
	{
		public LoginIdDTO User { get; set; }
		public DateTime AcessTime { get; set; }
		public Guid ProdutoId { get; set; }
	}
}
