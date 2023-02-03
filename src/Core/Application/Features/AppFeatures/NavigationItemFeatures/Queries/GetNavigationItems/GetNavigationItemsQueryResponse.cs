using System;
namespace Application.Features.AppFeatures.NavigationItemFeatures.Queries.GetNavigationItems
{
	public record GetNavigationItemsQueryResponse(
		int results,
		IList<Domain.AppEntities.NavigationItem> NavigationItems
		);
	
}

