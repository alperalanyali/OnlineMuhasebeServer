using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Commands.UpdateUserCompany
{
	public sealed record UpdateUserCompanyCommand(
		string Id,
		string UserId,
		string CompanyId
		):ICommand<UpdateUserCompanyCommandResponse>;
	
}

