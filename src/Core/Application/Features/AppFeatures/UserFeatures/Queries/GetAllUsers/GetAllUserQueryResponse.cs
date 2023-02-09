
using System;
using Domain.Dtos;

namespace Application.Features.AppFeatures.UserFeatures.Queries.GetAllUsers
{
	public record GetAllUserQueryResponse(
		int results,
		IEnumerable<UserDto> Data
		);
	
}

