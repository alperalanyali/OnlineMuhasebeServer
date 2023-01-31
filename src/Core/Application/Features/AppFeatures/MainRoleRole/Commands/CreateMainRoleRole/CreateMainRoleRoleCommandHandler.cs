using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRoleRole.Commands.CreateMainRoleRole
{
    public class CreateMainRoleRoleCommandHandler : ICommandHandler<CreateMainRoleRoleCommand, CreateMainRoleRoleCommandResponse>
    {
        private readonly IMainRoleRoleService _mainRoleRoleService;

        public CreateMainRoleRoleCommandHandler(IMainRoleRoleService mainRoleRoleService)
        {
            _mainRoleRoleService = mainRoleRoleService;
        }

        public async Task<CreateMainRoleRoleCommandResponse> Handle(CreateMainRoleRoleCommand request, CancellationToken cancellationToken)
        {
            Domain.AppEntities.MainRoleRole mainRoleRole = new Domain.AppEntities.MainRoleRole(
                    mainRoleId:request.MainRoleId,
                    roleId:request.RoleId                  
                );
            await _mainRoleRoleService.CreateAsync(mainRoleRole, cancellationToken);

            return new();
        }
    }
}

