using System;
using MediatR;

namespace Application.Features.AppFeatures.AppUserFeatures.Login
{
	public sealed class LoginRequest: IRequest<LoginResponse>
	{
		public string EmailOrUsername { get; set; }

		public string Password { get; set; }
			
	}
}

