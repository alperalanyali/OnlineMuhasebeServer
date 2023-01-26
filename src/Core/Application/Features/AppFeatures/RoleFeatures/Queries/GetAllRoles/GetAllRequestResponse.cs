using System;
using Domain.AppEntities.Identity;

namespace Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
	public sealed class GetAllRequestResponse
	{
		public int results { get; set; }
		public IList<AppRole> Roles { get; set; }
	}
}

