using System;
using Domain.AppEntities;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Queries.GetUserCompanyByUserId
{
	public sealed record GetUserCompanyByUserIdCommandResponse(
		int results,
		IList<AppUserCompany> UserCompanies
		);
	
}

