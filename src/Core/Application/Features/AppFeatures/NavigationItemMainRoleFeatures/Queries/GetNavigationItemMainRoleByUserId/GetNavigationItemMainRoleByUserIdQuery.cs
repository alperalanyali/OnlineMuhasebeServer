using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleByUserId
{
	public record GetNavigationItemMainRoleByUserIdQuery(
		string UserId
	):IQuery<GetNavigationItemMainRoleByUserIdQueryRespone>;
	
}

