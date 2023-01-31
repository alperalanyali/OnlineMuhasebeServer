using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRoleRole.Commands.CreateMainRoleRole
{
	public record CreateMainRoleRoleCommand(
			string MainRoleId,
			string RoleId

		) :ICommand<CreateMainRoleRoleCommandResponse>;

}

