using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRoleRole.Queries.GetAllMainRoleRoles
{
    public class GetAllMainRoleRolesCommandHandler : ICommandHandler<GetAllMainRoleRolesCommand, GetAllMainRoleRolesCommandResponse>
    {
        private readonly IMainRoleRoleService _mainRoleRoleService;

        public GetAllMainRoleRolesCommandHandler(IMainRoleRoleService mainRoleRoleService)
        {
            _mainRoleRoleService = mainRoleRoleService;
        }

        public async Task<GetAllMainRoleRolesCommandResponse> Handle(GetAllMainRoleRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await _mainRoleRoleService.GetMainRoleRoleAsync();

            return new(result.Count(), result);
        }
    }
}

