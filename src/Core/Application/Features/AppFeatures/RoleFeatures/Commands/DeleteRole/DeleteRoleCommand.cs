using System;
using Application.Messaging;
using MediatR;

namespace Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
	public sealed record DeleteRoleCommand(string Id) : ICommand<DeleteRoleCommandResponse>;
	
}

