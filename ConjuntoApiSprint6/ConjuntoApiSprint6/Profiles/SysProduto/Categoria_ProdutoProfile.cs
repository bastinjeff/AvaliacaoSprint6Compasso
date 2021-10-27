using AutoMapper;
using ConjuntoApiSprint6.DTOs.SysProduto.Get;
using ConjuntoApiSprint6.DTOs.SysProduto.New;
using ConjuntoApiSprint6.DTOs.SysProduto.Update;
using ConjuntoApiSprint6.Models.SysProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Profiles.SysProduto
{
	public class Categoria_ProdutoProfile : Profile
	{
		public Categoria_ProdutoProfile()
		{
			CreateMap<NewCategoria_ProdutoDTO, Categoria_Produto>();
			CreateMap<Categoria_Produto, GetCategoria_ProdutoDTO>();
			CreateMap<UpdateCategoria_ProdutoDTO, Categoria_Produto>();
		}
	}
}
