using AutoMapper;
using ConjuntoApiSprint6.DTOs.SysProduto.Get;
using ConjuntoApiSprint6.DTOs.SysProduto.New;
using ConjuntoApiSprint6.Models.SysProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Profiles.SysProduto
{
	public class ProdutoProfile : Profile
	{
		public ProdutoProfile()
		{
			CreateMap<NewProdutoDTO, Produto>();
			CreateMap<Produto, GetProdutoDTO>();
		}
	}
}
