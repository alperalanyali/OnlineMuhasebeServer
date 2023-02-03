using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Commands.UpdateNavigationItemMainRole
{
	public record UpdateNavigationItemMainRoleCommand(
		string Id,
		string NavigationItemId,
		string MainRoleId

		):ICommand<UpdateNavigationItemMainRoleCommandResponse>;

}

