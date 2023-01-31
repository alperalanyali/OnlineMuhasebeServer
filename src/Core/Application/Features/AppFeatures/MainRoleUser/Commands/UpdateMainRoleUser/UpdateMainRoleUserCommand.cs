using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRoleUser.Commands.UpdateMainRoleUser
{
	public record UpdateMainRoleUserCommand(
		string Id,
		string MainRoleId,
		string UserId,
		string CompanyId
		):ICommand<UpdateMainRoleUserCommandResponse>;

}

