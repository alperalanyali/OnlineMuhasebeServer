using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRoleUser.Queries.GetMainRoleUserByUserId
{
	public record GetMainRoleUserByUserIdQuery(
		string UserId
		):IQuery<GetMainRoleUserByUserIdQueryResponse>;
	
}

