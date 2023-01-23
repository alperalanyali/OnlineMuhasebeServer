using System;
using Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AutoMapper;
using Domain.AppEntities;

namespace Persistence.Mapping
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateCompanyRequest, Company>().ReverseMap();
		}
	}
}

