using System;
using Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using AutoMapper;
using Domain.AppEntities;
using Domain.CompanyEntities;

namespace Persistence.Mapping
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateCompanyRequest, Company>().ReverseMap();
			CreateMap<CreateUCAFRequest, UCAF>().ReverseMap();
		}
	}
}

