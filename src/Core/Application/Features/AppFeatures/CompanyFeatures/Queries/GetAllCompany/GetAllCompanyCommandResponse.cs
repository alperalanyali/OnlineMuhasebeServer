using System;
using Domain.AppEntities;

namespace Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany
{
	public record GetAllCompanyCommandResponse(
		int results ,
		IList<Company> companies
		);
	
}

