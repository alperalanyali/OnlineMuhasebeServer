using System;
using Domain.AppEntities.Identity;

namespace Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
	public sealed record GetAllRequestCommandResponse(
		int results,
         IList<AppRole> Data);
   
}

