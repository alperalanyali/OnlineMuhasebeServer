using System;
namespace Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole
{
	public sealed class CreateRoleResponse
	{
		public bool IsSuccess { get; set; } = false;
		public string Message { get; set; } = "Rol basarili sekilde olusturulmustur!";
	}
}

