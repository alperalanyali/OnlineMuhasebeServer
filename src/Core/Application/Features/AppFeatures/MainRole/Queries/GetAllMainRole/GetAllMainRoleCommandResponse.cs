using System;
using Domain.Dtos;

namespace Application.Features.AppFeatures.MainRole.Queries.GetAllMainRole
{
	public sealed record GetAllMainRoleCommandResponse(
		int results,
		IList<MainRoleDto> Data
		);
	
}

