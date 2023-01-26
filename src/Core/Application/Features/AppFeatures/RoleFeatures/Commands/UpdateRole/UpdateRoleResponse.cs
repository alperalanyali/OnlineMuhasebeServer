using System;
namespace Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
	public sealed class UpdateRoleResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; } = "Kayit basarili sekilde guncellenmistir";
	}
}

