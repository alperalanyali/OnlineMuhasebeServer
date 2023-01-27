using System;
using Application.Messaging;
using MediatR;

namespace Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
	public  sealed record GelAllRolesCommand() : IQuery<GetAllRequestCommandResponse>;
	
}

