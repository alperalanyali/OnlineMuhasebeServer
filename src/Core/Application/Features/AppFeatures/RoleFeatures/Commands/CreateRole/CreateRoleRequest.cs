using System;
using MediatR;

namespace Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole
{
	public sealed class CreateRoleRequest :IRequest<CreateRoleResponse>
	{
		public string Code { get; set; }
		public string Name { get; set; }
	}
}

