using System;
using Domain.AppEntities;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleByMainRoleId
{
	public record GetNavigationItemMainRoleByMainRoleIdQueryRespone(
		int Results,
		IList<NavigationItemMainRole> NavigationItemMainRoles
		);
	
}

