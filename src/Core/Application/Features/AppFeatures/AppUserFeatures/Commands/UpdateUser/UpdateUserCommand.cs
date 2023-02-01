using System;
using Application.Messaging;
using Domain.AppEntities.Identity;

namespace Application.Features.AppFeatures.AppUserFeatures.Commands.UpdateUser
{
	public record UpdateUserCommand(
		string Id,
		string UserName,
		string Email,
		string Password,
		string FullName

		):ICommand<UpdateUserCommandResponse>;
	
}

