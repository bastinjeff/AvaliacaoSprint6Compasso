using ConjuntoApiSprint6.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Models.Auditoria
{
	public class ErrorObject
	{
		public string ErrorAbstract { get; set; }
		public string ErrorMessage { get; set; }
		public DateTime ErrorTime { get; set; }
	}
}
