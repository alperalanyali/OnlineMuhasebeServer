using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.AuthFeatures.Quries.GetRolesByUserIdAndCompanyId
{
	public record GetRolesByUserIdAndCompanyIdQuery(
		string UserId,
		string CompanyId
		):IQuery<GetRolesByUserIdAndCompanyIdQueryResponse>;
	
}

