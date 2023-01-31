using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany
{
	public record GetAllCompanyCommand() :ICommand<GetAllCompanyCommandResponse>;

}

