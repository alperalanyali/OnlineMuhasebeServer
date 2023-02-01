using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Queries.GetAllUserCompany
{
	public sealed record GetAllUserCompanyCommand():ICommand<GetAllUserCompanyCommandResponse>;

}

