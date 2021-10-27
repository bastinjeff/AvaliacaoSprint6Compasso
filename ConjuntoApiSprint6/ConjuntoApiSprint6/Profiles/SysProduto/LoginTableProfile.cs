using AutoMapper;
using ConjuntoApiSprint6.DTOs.User.Get;
using ConjuntoApiSprint6.DTOs.User.New;
using ConjuntoApiSprint6.Models.SysProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Profiles.SysProduto
{
	public class LoginTableProfile : Profile
	{
		public LoginTableProfile()
		{
			CreateMap<NewLoginDTO, LoginTable>();
			CreateMap<LoginTable, GetLoginDTO>();
		}
	}
}
