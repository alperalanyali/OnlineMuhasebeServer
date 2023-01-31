using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRoleUser.Commands.CreateMainRoleUser
{
	public record CreateMainRoleUserCommand(
		string UserId,
		string MainRoleId,
		string CompanyId

		) :ICommand<CreateMainRoleUserCommandResponse>;
	
}

