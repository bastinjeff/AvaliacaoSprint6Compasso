using AutoMapper;
using ConjuntoApiSprint6.Contexts;
using ConjuntoApiSprint6.DTOs.SysCliente.Get;
using ConjuntoApiSprint6.DTOs.SysCliente.New;
using ConjuntoApiSprint6.DTOs.SysCliente.Update;
using ConjuntoApiSprint6.Models.SysCliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SysClienteController : MainController
	{
		SysClienteDbContext ClienteDbContext;
		public SysClienteController(SysClienteDbContext ClienteDbContext, IMapper mapper) : base(mapper)
		{
			this.ClienteDbContext = ClienteDbContext;
		}

		[HttpGet]
		public IActionResult ReturnAll()
		{
			var Clientes = ClienteDbContext.Clientes.Include(X => X.Enderecos).ThenInclude(X => X.UF);
			return Ok(Clientes);
		}

		[HttpPost]
		public IActionResult NewCliente([FromBody] NewClienteDTO NewDTO)
		{
			var New = mapper.Map<Cliente>(NewDTO);
			//var UFExists = ClienteDbContext.Estados.FirstOrDefault(X => X.UF == New.Enderecos.)			
			CheckIfUFExists(New);
			ClienteDbContext.Clientes.Add(New);
			ClienteDbContext.SaveChanges();
			return CreatedAtAction(nameof(GetCliente),new { id = New.Id }, NewDTO);
		}

		[HttpGet("{id}")]
		public IActionResult GetCliente(Guid Id)
		{
			var Cliente = ReturnClienteFullInfo(Id);
			if(Cliente == null)
			{
				return NotFound();
			}
			var ClienteDTO = mapper.Map<GetClienteDTO>(Cliente);
			return Ok(ClienteDTO);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCliente(Guid Id)
		{
			var DCliente = ClienteDbContext.Clientes.FirstOrDefault(X => X.Id == Id);
			ClienteDbContext.Remove(DCliente);
			ClienteDbContext.SaveChanges();
			return NoContent();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCliente(Guid Id, [FromBody] UpdateClienteDTO UpdateCliente)
		{
			Cliente DbCliente = ReturnClienteFullInfo(Id);
			mapper.Map(UpdateCliente, DbCliente);
			CheckIfUFExists(DbCliente);
			ClienteDbContext.SaveChanges();
			return NoContent();
		}

		private Cliente ReturnClienteFullInfo(Guid Id)
		{
			return ClienteDbContext.Clientes.Include(X => X.Enderecos).ThenInclude(X => X.UF).FirstOrDefault(X => X.Id == Id);
		}

		private void CheckIfUFExists(Cliente New)
		{
			foreach (var Endereco in New.Enderecos)
			{
				var UFExist = ClienteDbContext.Estados.FirstOrDefault(X => X.UF == Endereco.UF.UF);
				if (UFExist != null)
				{
					Console.WriteLine("Achou {0}", UFExist.Id);
					ClienteDbContext.Entry(Endereco).Property("EstadoId").CurrentValue = UFExist.Id;
					Endereco.UF = null;
				}
			}
		}
	}
}
