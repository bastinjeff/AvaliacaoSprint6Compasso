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
	public class TagProfile : Profile
	{
		public TagProfile()
		{
			CreateMap<NewTagDTO, Tag>();
			CreateMap<Tag, GetTagDTO>();
			CreateMap<UpdateTagDTO, Tag>();
		}
	}
}
