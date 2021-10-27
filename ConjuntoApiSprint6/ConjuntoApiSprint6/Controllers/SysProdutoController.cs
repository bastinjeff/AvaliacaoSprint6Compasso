using AutoMapper;
using ConjuntoApiSprint6.Contexts;
using ConjuntoApiSprint6.DTOs.SysProduto.Get;
using ConjuntoApiSprint6.DTOs.SysProduto.New;
using ConjuntoApiSprint6.Models.SysProduto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class SysProdutoController : MainController
	{
		SysProdutoDbContext ProdutoDbContext;
		public SysProdutoController(SysProdutoDbContext ProdutoDbContext, IMapper mapper) : base(mapper)
		{
			this.ProdutoDbContext = ProdutoDbContext;
		}

		[HttpPost]
		public IActionResult NewProduto([FromBody] NewProdutoDTO newProdutoDTO)
		{
			var NewProduto = mapper.Map<Produto>(newProdutoDTO);
			//Console.WriteLine(NewProduto.cidades[0].cidade.cidade);
			CheckIfUFExists(NewProduto);
			CheckIfCidadeExists(NewProduto);
			CheckIfTagExists(NewProduto);
			CheckIfCategoriaExists(NewProduto);			
			ProdutoDbContext.Produtos.Add(NewProduto);
			ProdutoDbContext.SaveChanges();
			return CreatedAtAction(nameof(GetProduto),new { Id = NewProduto.Id },newProdutoDTO);
		}

		[HttpGet]
		public IActionResult GetAllProduto()
		{
			var Produtos = ReturnAllProdutoInfo();
			var ProdutosDTO = mapper.Map <IEnumerable<GetProdutoDTO>>(Produtos);
			return Ok(ProdutosDTO);				
		}

		[HttpGet("{id}")]
		public IActionResult GetProduto(Guid Id)
		{
			var ReturnedProduto = ReturnAllProdutoInfo().FirstOrDefault(X => X.Id == Id);
			if(ReturnedProduto == null)
			{
				return NotFound();
			}
			var ProdutoDTO = mapper.Map<GetProdutoDTO>(ReturnedProduto);
			return Ok(ProdutoDTO);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduto(Guid Id)
		{
			var ReturnedProduto = ReturnAllProdutoInfo().FirstOrDefault(X => X.Id == Id);
			if (ReturnedProduto == null)
			{
				return NotFound();
			}
			ProdutoDbContext.Produtos.Remove(ReturnedProduto);
			ProdutoDbContext.SaveChanges();
			return NoContent();
		}

		private IIncludableQueryable<Produto,Estado> ReturnAllProdutoInfo()
		{
			return ProdutoDbContext.Produtos.
				Include(X => X.categorias).ThenInclude(X => X.categoria).
				Include(X => X.Tags).ThenInclude(X => X.tag).
				Include(X => X.cidades).ThenInclude(X => X.cidade).ThenInclude(X => X.estado);
		}

		private void CheckIfCidadeExists(Produto New)
		{
			foreach(var Cidade in New.cidades)
			{
				Cidade CidadeExist;
				if(Cidade.cidade.estado != null)
				{
					CidadeExist = ProdutoDbContext.Cidades.
					FirstOrDefault(X => X.cidade == Cidade.cidade.cidade 
					&& X.estado.UF == Cidade.cidade.estado.UF);
				}
				else
				{
					var NewCidadeEstadoId = (Guid)ProdutoDbContext.Entry(Cidade.cidade).Property("EstadoId").CurrentValue;
					CidadeExist = ProdutoDbContext.Cidades.
					Single(X => (X.cidade == Cidade.cidade.cidade)
					&& (EF.Property<Guid>(X, "EstadoId") == NewCidadeEstadoId));
				}
				
				if(CidadeExist != null)
				{
					ProdutoDbContext.Entry(Cidade).Property("CidadeId").CurrentValue = CidadeExist.Id;
					Cidade.cidade = null;
				}
			}
		}

		private void CheckIfCategoriaExists(Produto New)
		{
			foreach(var Categoria in New.categorias)
			{
				var CategoriaExist = ProdutoDbContext.Categorias.FirstOrDefault(X => X.categoria == Categoria.categoria.categoria);
				if(CategoriaExist != null)
				{					
					ProdutoDbContext.Entry(Categoria).Property("CategoriaId").CurrentValue = CategoriaExist.Id;
					Categoria.categoria = null;
				}
			}
		}

		private void CheckIfTagExists(Produto New)
		{
			foreach(var Tag in New.Tags)
			{
				var TagExist = ProdutoDbContext.Tags.FirstOrDefault(X => X.tag == Tag.tag.tag);
				if(TagExist != null)
				{
					ProdutoDbContext.Entry(Tag).Property("TagId").CurrentValue = TagExist.Id;
					Tag.tag = null;
				}
			}
		}
		private void CheckIfUFExists(Produto New)
		{
			foreach (var Cidade in New.cidades)
			{
				var UFExist = ProdutoDbContext.Estados.FirstOrDefault(X => X.UF == Cidade.cidade.estado.UF);
				if (UFExist != null)
				{
					ProdutoDbContext.Entry(Cidade.cidade).Property("EstadoId").CurrentValue = UFExist.Id;
					Cidade.cidade.estado = null;
				}
			}
		}
	}
}
