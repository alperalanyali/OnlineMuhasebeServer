using System;
namespace Application.Features.AppFeatures.MainRoleUser.Queries.GetAllMainRoleUser
{
	public record GetAllMainRoleUserCommandResponse(
		int result,
		IList<Domain.AppEntities.MainRoleUser> MainRoleUsers
		);
	
}

