using System;
namespace Application.Features.AppFeatures.AuthFeatures.Quries.GetRolesByUserIdAndCompanyId
{
	public sealed record GetRolesByUserIdAndCompanyIdQueryResponse(
		int results,
		IList<string> Roles
		);
	
}

