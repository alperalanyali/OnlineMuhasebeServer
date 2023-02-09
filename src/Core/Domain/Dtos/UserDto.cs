using System;
namespace Domain.Dtos
{
	public record UserDto(
		string Id,
		string Username,
		string FullName,	
		string Phone,
		string Email
		);
	
}

