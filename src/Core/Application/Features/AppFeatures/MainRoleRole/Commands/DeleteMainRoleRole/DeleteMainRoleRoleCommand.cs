using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRoleRole.Commands.DeleteMainRoleRole
{
	public record DeleteMainRoleRoleCommand(
		string Id
		):ICommand<DeleteMainRoleRoleCommandResponse>;
	
}

