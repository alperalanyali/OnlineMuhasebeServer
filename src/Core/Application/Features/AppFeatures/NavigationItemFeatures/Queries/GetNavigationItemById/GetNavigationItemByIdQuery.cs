using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Queries.GetNavigationItemById
{
	public record GetNavigationItemByIdQuery(
		string Id):IQuery<GetNavigationItemByIdQueryResponse>;
	
}

