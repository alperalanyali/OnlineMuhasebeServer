using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Queries.GetUserCompanyByUserId
{
	public sealed record GetUserCompanyByUserIdCommand(
		string UserId
		):ICommand<GetUserCompanyByUserIdCommandResponse>;
	
}

