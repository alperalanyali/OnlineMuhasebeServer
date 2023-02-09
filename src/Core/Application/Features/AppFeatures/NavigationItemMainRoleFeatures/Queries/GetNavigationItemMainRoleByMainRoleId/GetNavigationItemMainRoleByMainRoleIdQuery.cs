using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleByMainRoleId
{
	public record GetNavigationItemMainRoleByMainRoleIdQuery(
		string UserId
	):IQuery<GetNavigationItemMainRoleByMainRoleIdQueryRespone>;
	
}

