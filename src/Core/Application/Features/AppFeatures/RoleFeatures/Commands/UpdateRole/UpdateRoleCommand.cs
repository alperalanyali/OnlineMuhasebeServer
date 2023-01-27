using System;
using Application.Messaging;
using MediatR;

namespace Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
	public sealed record UpdateRoleCommand(
			string Id,
			string Code,
			string Name
		) : ICommand<UpdateRoleCommandResponse>;


}

