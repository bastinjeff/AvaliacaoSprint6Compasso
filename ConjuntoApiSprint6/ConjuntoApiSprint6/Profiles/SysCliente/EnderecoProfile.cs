using AutoMapper;
using ConjuntoApiSprint6.DTOs.SysCliente;
using ConjuntoApiSprint6.DTOs.SysCliente.Get;
using ConjuntoApiSprint6.DTOs.SysCliente.New;
using ConjuntoApiSprint6.DTOs.SysCliente.Update;
using ConjuntoApiSprint6.Models.SysCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Profiles.SysCliente
{
	public class EnderecoProfile : Profile
	{
		public EnderecoProfile()
		{
			CreateMap<NewEnderecoDTO, Endereco>();
			CreateMap<Endereco, GetEnderecoDTO>();
			CreateMap<UpdateEnderecoDTO, Endereco>();
		}
	}
}
