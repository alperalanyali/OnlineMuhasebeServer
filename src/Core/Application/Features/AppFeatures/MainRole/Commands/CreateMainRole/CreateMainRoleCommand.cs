using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRole.Commands.CreateMainRole
{
	public record CreateMainRoleCommand(
			string Title,
			string CompanyId =null		
        ) :
		ICommand<CreateRoleResponse>;
	
}

