using System;
namespace Domain.Dtos
{
	public record NavigationItemMainRoleDto(
		string	Id,
		string	NavigationItemId,
		string	NavigationName,
		string	MainRoleId,
		string	MainRoleName
		);
	
}

