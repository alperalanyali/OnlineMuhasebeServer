using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Commands.DeleteNavigationItemMainRole
{
	public record DeleteNavigationItemMainRoleCommand(
		string Id
		): ICommand<DeleteNavigationItemMainRoleCommandResponse>;
	
}

