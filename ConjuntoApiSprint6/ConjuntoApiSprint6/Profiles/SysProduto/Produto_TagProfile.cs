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
	public class Produto_TagProfile : Profile
	{
		public Produto_TagProfile()
		{
			CreateMap<NewProduto_TagDTO, Produto_Tag>();
			CreateMap<Produto_Tag, GetProduto_TagDTO>();
			CreateMap<UpdateProduto_TagDTO, Produto_Tag>();
		}
	}
}
