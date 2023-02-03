using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleById
{
	public record GetNavigationItemMainRoleByIdQuery(string Id):IQuery<GetNavigationItemMainRoleByIdQueryResponse>;


}

