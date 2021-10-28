using AutoMapper;
using ConjuntoApiSprint6.Contexts;
using ConjuntoApiSprint6.DTOs.User;
using ConjuntoApiSprint6.DTOs.User.Get;
using ConjuntoApiSprint6.DTOs.User.New;
using ConjuntoApiSprint6.Models.SysProduto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class LoginController : MainController
	{
		SysProdutoDbContext ProdutoDbContext;
		public LoginController(SysProdutoDbContext ProdutoDbContext, IMapper mapper) : base(mapper)
		{
			this.ProdutoDbContext = ProdutoDbContext;
		}

		[HttpPost]
		public IActionResult NewLogin([FromBody] NewLoginDTO LoginInfo)
		{
			var Logins = ProdutoDbContext.LoginTables;
			foreach(var login in Logins)
			{
				if(login.Login == LoginInfo.Login)
				{
					return BadRequest();
				}
			}
			var NewLogin = mapper.Map<LoginTable>(LoginInfo);
			Logins.Add(NewLogin);
			ProdutoDbContext.SaveChanges();
			return CreatedAtAction(nameof(GetLogin),new { Id = NewLogin.Id },LoginInfo);
		}

		[HttpGet("{id}")]
		public IActionResult GetLogin(Guid Id)
		{
			var Login = ProdutoDbContext.LoginTables.FirstOrDefault(X => X.Id == Id);
			var LoginDTO = mapper.Map<GetLoginDTO>(Login);
			return Ok(LoginDTO);
		}

		public IActionResult Logar([FromBody] LoginDTO UserLogin)
		{
			var login = ProdutoDbContext.LoginTables;
			foreach(var Log in login)
			{
				if(Log.Login == UserLogin.Login)
				{
					if(Log.Senha == UserLogin.Senha)
					{
						var LogId = new LoginIdDTO();
						LogId.Id = Log.Id;
						return Ok(LogId);
					}
				}
			}
			return BadRequest();
		}
	}
}
