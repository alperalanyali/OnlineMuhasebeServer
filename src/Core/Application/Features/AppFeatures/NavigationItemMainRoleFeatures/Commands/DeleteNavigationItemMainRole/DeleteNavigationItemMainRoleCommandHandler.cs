using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Commands.DeleteNavigationItemMainRole
{
    public class DeleteNavigationItemMainRoleCommandHandler : ICommandHandler<DeleteNavigationItemMainRoleCommand, DeleteNavigationItemMainRoleCommandResponse>
    {
        private readonly INavigationItemMainRoleService _navItemMainRoleService;

        public DeleteNavigationItemMainRoleCommandHandler(INavigationItemMainRoleService navigationItemMainRoleService)
        {
            _navItemMainRoleService = navigationItemMainRoleService;
        }
        public async Task<DeleteNavigationItemMainRoleCommandResponse> Handle(DeleteNavigationItemMainRoleCommand request, CancellationToken cancellationToken)
        {
            await _navItemMainRoleService.DeleteNavigationItemMainRoleById(request.Id,cancellationToken);
            return new();
        }
    }
}

