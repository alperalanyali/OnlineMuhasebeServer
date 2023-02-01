using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Commands.DeleteUserCompany
{
	public sealed record DeleteUserCompanyCommand(
		string Id
		):ICommand<DeleteUserCompanyCommandResponse>;
	
}

