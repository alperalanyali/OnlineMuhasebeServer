using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRole.Commands.DeleteMainRole
{
    public class DeleteMainRoleCommandHandler : ICommandHandler<DeleteMainRoleCommand, DeleteMainRoleCommandResponse>
    {
        private readonly IMainRoleService _mainRoleService;

        public DeleteMainRoleCommandHandler(IMainRoleService mainRoleService)
        {
            _mainRoleService = mainRoleService;
        }

        public async Task<DeleteMainRoleCommandResponse> Handle(DeleteMainRoleCommand request, CancellationToken cancellationToken)
        {
            await _mainRoleService.DeleteMainRole(request.Id, cancellationToken);
            return new();
        }
    }
}

