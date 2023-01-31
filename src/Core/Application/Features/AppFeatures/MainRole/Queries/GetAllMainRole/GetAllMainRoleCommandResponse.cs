using System;
namespace Application.Features.AppFeatures.MainRole.Queries.GetAllMainRole
{
	public sealed record GetAllMainRoleCommandResponse(
		int results,
		IList<Domain.AppEntities.MainRole> mainRoles
		);
	
}

