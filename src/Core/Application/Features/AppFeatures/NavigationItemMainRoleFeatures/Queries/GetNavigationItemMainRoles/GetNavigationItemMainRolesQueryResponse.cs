using System;
using Domain.AppEntities;
using Domain.Dtos;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoles
{
	public record GetNavigationItemMainRolesQueryResponse(
		int Results,
		IList<NavigationItemMainRoleDto> Data
		);
	
}

