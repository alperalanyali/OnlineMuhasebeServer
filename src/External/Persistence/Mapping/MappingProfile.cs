using System;
using Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole;
using Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using AutoMapper;
using Domain.AppEntities;
using Domain.AppEntities.Identity;
using Domain.CompanyEntities;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Mapping
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateCompanyCommand, Company>().ReverseMap();
			CreateMap<CreateUCAFCommand, UCAF>().ReverseMap();
			//CreateMap<CreateRoleCommand, IdentityRole>().ReverseMap();

			CreateMap<CreateRoleCommand, AppRole>().ReverseMap();
            
            
        }
	}
}

