using System;
using Domain.AppEntities;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoles
{
	public record GetNavigationItemMainRolesQueryResponse(
		int Results,
		IList<NavigationItemMainRole> NavigationItemMainRoles
		);
	
}

