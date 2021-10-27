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
	public class EstadoProfile : Profile
	{
		public EstadoProfile()
		{
			CreateMap<NewEstadoSysProdutoDTO, Estado>();
			CreateMap<Estado, GetEstadoSysProdutoDTO>();
		}
	}
}
