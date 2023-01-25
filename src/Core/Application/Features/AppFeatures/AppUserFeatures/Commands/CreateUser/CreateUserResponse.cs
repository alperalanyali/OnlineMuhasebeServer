using System;
namespace Application.Features.AppFeatures.AppUserFeatures.Commands.CreateUser
{
	public class CreateUserResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; } = "Kullanıcı kayıt işlemi başarılı şekilde gerçekleştirmiştir";
	}
}

