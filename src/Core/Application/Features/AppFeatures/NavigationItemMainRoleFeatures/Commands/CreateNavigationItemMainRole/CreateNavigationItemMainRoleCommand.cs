using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Commands.CreateNavigationItemMainRole
{
	public record CreateNavigationItemMainRoleCommand(
		string NavigationItemId,
		string	MainRoleId

		):ICommand<CreateNavigationItemMainRoleCommandResponse>;
	
}

