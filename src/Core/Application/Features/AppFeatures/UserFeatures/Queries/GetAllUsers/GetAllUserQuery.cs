using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.UserFeatures.Queries.GetAllUsers
{
	public record GetAllUserQuery():IQuery<GetAllUserQueryResponse>;
	
}

