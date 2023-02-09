using System;
using Domain.AppEntities;
using Domain.Dtos;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Queries.GetAllUserCompany
{
	public sealed record GetAllUserCompanyCommandResponse(
		int results,
		IList<UserCompanyDto> Data
		);
	
}

