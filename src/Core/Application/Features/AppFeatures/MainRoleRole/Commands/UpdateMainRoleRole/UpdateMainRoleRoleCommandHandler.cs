using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRoleRole.Commands.UpdateMainRoleRole
{
    public class UpdateMainRoleRoleCommandHandler : ICommandHandler<UpdateMainRoleRoleCommand, UpdateMainRoleRoleCommandResponse>
    {
        private readonly IMainRoleRoleService _mainRoleRoleService;
        public UpdateMainRoleRoleCommandHandler(IMainRoleRoleService mainRoleRoleService)
        {
            _mainRoleRoleService = mainRoleRoleService;
        }
        public async Task<UpdateMainRoleRoleCommandResponse> Handle(UpdateMainRoleRoleCommand request, CancellationToken cancellationToken)
        {
            Domain.AppEntities.MainRoleRole mainRoleRole =await _mainRoleRoleService.GetById(request.Id);
            mainRoleRole.MainRoleId = request.MainRoleId;
            mainRoleRole.RoleId = request.RoleId;
            await _mainRoleRoleService.UpdateAsync(mainRoleRole, cancellationToken);

            return new();
        }
    }
}

