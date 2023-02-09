using System;
using Domain.AppEntities;
using Domain.Dtos;

namespace Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany
{
	public record GetAllCompanyCommandResponse(
		int results ,
		IList<CompanyDto> Data
		);
	
}

