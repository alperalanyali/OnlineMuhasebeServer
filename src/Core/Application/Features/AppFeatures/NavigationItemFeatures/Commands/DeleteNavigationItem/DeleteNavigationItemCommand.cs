using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Commands.DeleteNavigationItem
{
	public record DeleteNavigationItemCommand(
		string Id
		):ICommand<DeleteNavigationItemCommandResponse>;
	
}

