using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Commands.CreateNavigationItemMainRole
{
    public class CreateNavigationItemMainRoleCommandHandler : ICommandHandler<CreateNavigationItemMainRoleCommand, CreateNavigationItemMainRoleCommandResponse>
    {

        private readonly INavigationItemMainRoleService _navItemMainRoleService;

        public CreateNavigationItemMainRoleCommandHandler(INavigationItemMainRoleService navItemMainRoleService)
        {
            _navItemMainRoleService = navItemMainRoleService;
        }

        public async Task<CreateNavigationItemMainRoleCommandResponse> Handle(CreateNavigationItemMainRoleCommand request, CancellationToken cancellationToken)
        {
            var navItemMainRole = new NavigationItemMainRole(request.NavigationItemId,request.MainRoleId);

            await _navItemMainRoleService.CreateAsync(navItemMainRole, cancellationToken);

            return new();
        }
    }
}

