using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Commands.UpdateNavigationItem
{
	public record UpdateNavigationItemCommand(
		string Id,
		string NavigationName,
		string NavigationPath,
		string TopNavigationId
		):ICommand<UpdateNavigationItemCommandResponse>;
	
}

