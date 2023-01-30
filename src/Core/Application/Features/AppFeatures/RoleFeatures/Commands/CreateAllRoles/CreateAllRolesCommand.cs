using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles
{
	public record CreateAllRolesCommand(

		) :ICommand<CreateAllRolesResponse>;
	
}

