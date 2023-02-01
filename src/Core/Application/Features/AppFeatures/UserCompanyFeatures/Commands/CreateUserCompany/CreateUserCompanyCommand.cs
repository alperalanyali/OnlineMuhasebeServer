using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Commands.CreateUserCompany
{
	public sealed record CreateUserCompanyCommand(
		string UserId,
		string CompanyId
		):ICommand<CreateUserCompanyCommandResponse>;
	
}

