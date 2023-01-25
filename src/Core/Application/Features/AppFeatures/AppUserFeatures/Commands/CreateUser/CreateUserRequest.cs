using System;
using MediatR;

namespace Application.Features.AppFeatures.AppUserFeatures.Commands.CreateUser
{
	public class CreateUserRequest:IRequest<CreateUserResponse>
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }

	}
}

