using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRoleRole.Commands.UpdateMainRoleRole
{
	public record UpdateMainRoleRoleCommand(
		string Id,
		string MainRoleId,
		string RoleId
		) :ICommand<UpdateMainRoleRoleCommandResponse>;
	
}

