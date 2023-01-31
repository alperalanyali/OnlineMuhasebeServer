using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRole.Commands.DeleteMainRole
{
	public record DeleteMainRoleCommand(
		string Id
		) :ICommand<DeleteMainRoleCommandResponse>;

}

