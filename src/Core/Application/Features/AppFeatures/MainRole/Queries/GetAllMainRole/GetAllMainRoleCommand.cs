using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRole.Queries.GetAllMainRole
{
	public record GetAllMainRoleCommand() :ICommand<GetAllMainRoleCommandResponse>;
	
}

