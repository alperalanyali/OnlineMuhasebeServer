using System;
namespace Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole
{
	public sealed record CreateRoleCommandResponse(
        bool IsSuccess = false,
        string Message = "Rol basarili sekilde olusturulmustur!"
        );	
}

