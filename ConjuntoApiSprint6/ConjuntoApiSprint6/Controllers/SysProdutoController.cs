using AutoMapper;
using ConjuntoApiSprint6.Contexts;
using ConjuntoApiSprint6.DTOs.SysProduto.Get;
using ConjuntoApiSprint6.DTOs.SysProduto.New;
using ConjuntoApiSprint6.DTOs.SysProduto.Update;
using ConjuntoApiSprint6.DTOs.User;
using ConjuntoApiSprint6.Models.Auditoria;
using ConjuntoApiSprint6.Models.SysProduto;
using ConjuntoApiSprint6.Operations.Auditoria;
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
		SysClienteDbContext ClienteDbContext;
		string StringConncetionMongoDB = "mongodb://localhost:27017";
		string DatabaseName = "Auditoria";
		string ErrorColecctionName = "Errors";
		string UserAccessCollectionName = "UserAccess";

		public SysProdutoController(SysProdutoDbContext ProdutoDbContext, SysClienteDbContext ClienteDbContext, IMapper mapper) : base(mapper)
		{
			this.ProdutoDbContext = ProdutoDbContext;
			this.ClienteDbContext = ClienteDbContext;
		}

		[HttpPost]
		public IActionResult NewProduto([FromBody] NewProdutoDTO newProdutoDTO)
		{
			try
			{
				var NewProduto = mapper.Map<Produto>(newProdutoDTO);
				CheckIfUFExists(NewProduto);
				CheckIfCidadeExists(NewProduto);
				CheckIfTagExists(NewProduto);
				CheckIfCategoriaExists(NewProduto);
				ProdutoDbContext.Produtos.Add(NewProduto);
				ProdutoDbContext.SaveChanges();
				return CreatedAtAction(nameof(GetProduto), new { Id = NewProduto.Id }, newProdutoDTO);
			}
			catch (Exception E)
			{
				string ErrorAbstract = "Error while trying to add new Produto";
				InsertNewError(E, ErrorAbstract);
				return StatusCode(500);
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetProduto(Guid Id, [FromBody] LoginIdDTO User)
		{
			try
			{
				var ReturnedProduto = ReturnAllProdutoInfo().FirstOrDefault(X => X.Id == Id);
				if(ReturnedProduto == null)
				{
					return NotFound();
				}
				var ProdutoDTO = mapper.Map<GetProdutoDTO>(ReturnedProduto);
				return Ok(ProdutoDTO);

			}catch(Exception E)
			{
				string ErrorAbstract = "Error Trying to Get Produto by Id";
				InsertNewError(E, ErrorAbstract);
				return StatusCode(500);
			}
		}

		[HttpGet]
		public IActionResult GetProdutoWithFilter([FromQuery] ProdutoFilter Filtro, [FromQuery] ProdutoOrder Order, [FromBody] LoginIdDTO User)
		{
			try
			{
				var ProdutoDb = ReturnAllProdutoInfo().ToList();
				FilterProduto(ProdutoDb, Filtro, Order);
				var ProdutoDbDTO = mapper.Map<IEnumerable<GetProdutoDTO>>(ProdutoDb);
				DefineFrete(ProdutoDbDTO, User);
				return Ok(ProdutoDbDTO);
			}catch(Exception E)
			{
				string ErrorAbstract = "Error trying to get produto with filter";
				InsertNewError(E, ErrorAbstract);
				return StatusCode(500);
			}
		}

		private void FilterProduto(List<Produto> ProdutoDb, ProdutoFilter Filtro, ProdutoOrder Order)
		{
			if (!string.IsNullOrEmpty(Filtro.FilterDescricao))
			{
				ProdutoDb = ProdutoDb.Where(X => X.Descricao.Contains(Filtro.FilterDescricao)).ToList();
			}
			if (!string.IsNullOrEmpty(Filtro.FilterTag))
			{
				ProdutoDb = ProdutoDb.Where(X => X.Tags.All(Y => Y.tag.tag == Filtro.FilterTag)).ToList();
			}
			if (!string.IsNullOrEmpty(Filtro.FilterCategoria))
			{
				ProdutoDb = ProdutoDb.Where(X => X.categorias.All(Y => Y.categoria.categoria == Filtro.FilterCategoria)).ToList();
			}
			if (!string.IsNullOrEmpty(Order.FilterPrecoOrder))
			{
				if (Order.FilterPrecoOrder == "Asc")
				{
					ProdutoDb = ProdutoDb.OrderBy(X => X.Preco).ToList();
				}
				else if (Order.FilterPrecoOrder == "Desc")
				{
					ProdutoDb = ProdutoDb.OrderBy(X => X.Preco).Reverse().ToList();
				}
			}
		}

		private void DefineFrete(IEnumerable<GetProdutoDTO> ProdutoDbDTO, LoginIdDTO User)
		{
			var CurrentUser = ClienteDbContext.Clientes.Include(X => X.Enderecos).ThenInclude(X => X.UF).FirstOrDefault(X => X.Id == User.Id);
			var MainCidade = CurrentUser.Enderecos.FirstOrDefault(X => X.Principal);
			bool Achou = false;
			foreach (var Produto in ProdutoDbDTO)
			{
				Achou = true;
				foreach (var CP in Produto.cidades)
				{
					if (CP.cidade.cidade == MainCidade.Cidade && CP.cidade.estado.UF == MainCidade.UF.UF)
					{
						Achou = false;
					}
				}
				if (Achou)
				{
					Produto.Preco += 29.90;
					Produto.Frete = true;
				}
			}
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
				Cidade CidadeExist = null;
				if(Cidade.cidade.estado != null)
				{
					CidadeExist = ProdutoDbContext.Cidades.
					FirstOrDefault(X => X.cidade == Cidade.cidade.cidade 
					&& X.estado.UF == Cidade.cidade.estado.UF);
				}
				else
				{
					var NewCidadeEstadoId = (Guid)ProdutoDbContext.Entry(Cidade.cidade).Property("EstadoId").CurrentValue;
					try
					{
						CidadeExist = ProdutoDbContext.Cidades.
											Single(X => (X.cidade == Cidade.cidade.cidade)
											&& (EF.Property<Guid>(X, "EstadoId") == NewCidadeEstadoId));
					}catch(Exception C)
					{

					}
					
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

		private void InsertNewError(Exception E, string ErrorAbstract)
		{
			ErrorObject Error = new ErrorObject();
			Error.ErrorAbstract = ErrorAbstract;
			Error.ErrorMessage = E.Message;
			Error.ErrorTime = DateTime.Now;
			MongoDbOperations<ErrorObject>.InsertNewDataInMongoDb(StringConncetionMongoDB, DatabaseName, ErrorColecctionName, Error);
		}
	}
}
