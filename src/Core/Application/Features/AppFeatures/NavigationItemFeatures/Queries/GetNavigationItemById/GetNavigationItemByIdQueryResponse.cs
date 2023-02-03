using System;
using Domain.AppEntities;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Queries.GetNavigationItemById
{
	public record GetNavigationItemByIdQueryResponse(
		NavigationItem NavigationItem
		);
	
}

