using System;
using Domain.AppEntities;
using Domain.Dtos;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleByUserId
{
	public record GetNavigationItemMainRoleByUserIdQueryRespone(
		int Results,
		IList<NavigationItemDto> Data
		);
	
}

