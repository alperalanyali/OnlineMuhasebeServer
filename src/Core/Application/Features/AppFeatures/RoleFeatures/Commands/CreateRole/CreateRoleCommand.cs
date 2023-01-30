using System;
using Application.Messaging;
using MediatR;

namespace Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole
{
	public sealed record CreateRoleCommand(
		string Title,
		string Code,
		string Name
		)  :ICommand<CreateRoleCommandResponse>;
}

