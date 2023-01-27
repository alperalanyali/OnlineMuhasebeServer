using System;
using Application.Messaging;


namespace Application.Features.AppFeatures.AppUserFeatures.Login
{
	// Validation özelliğinden önceki hali
	//public sealed class LoginRequest: IRequest<LoginResponse>
	//{
	//	public string EmailOrUsername { get; set; }

	//	public string Password { get; set; }
			
	//}

	public sealed record LoginCommand(
		string EmailOrUsername,
		string Password
		) :ICommand<LoginCommandResponse>;
}

