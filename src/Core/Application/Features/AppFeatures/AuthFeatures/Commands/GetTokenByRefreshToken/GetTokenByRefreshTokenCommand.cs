using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.AuthFeatures.Commands.GetTokenByRefreshToken
{
	public sealed record GetTokenByRefreshTokenCommand(
		string UserId,
		string RefreshToken,
		string CompanyId
		):ICommand<GetTokenByRefreshTokenCommandResponse>;
	
}

