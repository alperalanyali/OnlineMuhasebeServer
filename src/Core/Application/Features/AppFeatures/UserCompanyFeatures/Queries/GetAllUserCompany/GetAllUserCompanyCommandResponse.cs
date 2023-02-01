using System;
using Domain.AppEntities;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Queries.GetAllUserCompany
{
	public sealed record GetAllUserCompanyCommandResponse(
		int results,
		IList<AppUserCompany> UserCompanies
		);
	
}

