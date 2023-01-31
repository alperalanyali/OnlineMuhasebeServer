using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRole.Commands.UpdateMainRole
{
	public record UpdateMainRoleCommand(
		string Id,
		string Title,
		string CompanyId
		):ICommand<UpdateMainRoleCommandResponse>;
	
}

