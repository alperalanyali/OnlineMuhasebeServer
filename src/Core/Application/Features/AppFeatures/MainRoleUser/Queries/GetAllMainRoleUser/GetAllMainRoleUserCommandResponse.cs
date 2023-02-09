using System;
using Domain.Dtos;

namespace Application.Features.AppFeatures.MainRoleUser.Queries.GetAllMainRoleUser
{
	public record GetAllMainRoleUserCommandResponse(
		int result,
		IList<MainRoleUserDto> Data
		);
	
}

