using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRoleUser.Commands.DeleteMainRoleUser
{
	public record DeleteMainRoleUserCommand(string Id):ICommand<DeleteMainRoleUserCommandResponse>;
	
}

