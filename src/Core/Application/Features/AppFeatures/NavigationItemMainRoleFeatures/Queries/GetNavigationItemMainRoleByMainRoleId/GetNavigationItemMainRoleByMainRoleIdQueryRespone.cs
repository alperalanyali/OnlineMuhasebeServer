using System;
using Domain.AppEntities;
using Domain.Dtos;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleByMainRoleId
{
	public record GetNavigationItemMainRoleByMainRoleIdQueryRespone(
		int Results,
		IList<NavigationItemDto> Data
		);
	
}

