using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRoleRole.Commands.DeleteMainRoleRole
{
    public class DeleteMainRoleRoleCommandHandler : ICommandHandler<DeleteMainRoleRoleCommand, DeleteMainRoleRoleCommandResponse>
    {
        private readonly IMainRoleRoleService _mainRoleRoleService;

        public DeleteMainRoleRoleCommandHandler(IMainRoleRoleService mainRoleRoleService)
        {
            _mainRoleRoleService = mainRoleRoleService;
        }

        public async Task<DeleteMainRoleRoleCommandResponse> Handle(DeleteMainRoleRoleCommand request, CancellationToken cancellationToken)
        {
            await _mainRoleRoleService.DeleteMainRoleRole(request.Id, cancellationToken);
            return new();
        }
    }
}

