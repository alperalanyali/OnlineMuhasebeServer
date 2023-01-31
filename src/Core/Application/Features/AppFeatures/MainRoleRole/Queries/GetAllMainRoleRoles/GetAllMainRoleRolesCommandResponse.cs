using System;
namespace Application.Features.AppFeatures.MainRoleRole.Queries.GetAllMainRoleRoles
{
	public record GetAllMainRoleRolesCommandResponse(
		int results,
		IList<Domain.AppEntities.MainRoleRole> MainRoleRoles
		);
	
}

