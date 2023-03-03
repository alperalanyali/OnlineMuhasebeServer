using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Commands.CreateNavigationItem
{
	public record CreateNavigationItemCommand(
		string NavigationName,
		string NavigationPath,
		string TopNavigationId,
		int Priority

		):ICommand<CreateNavigationItemCommandResponse>;
	
}

