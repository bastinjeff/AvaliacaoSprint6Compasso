using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Controllers
{
	public class MainController : ControllerBase
	{
		protected IMapper mapper;
		public MainController(IMapper mapper)
		{
			this.mapper = mapper;
		}
	}
}
