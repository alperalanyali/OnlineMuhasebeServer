using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Commands.UpdateNavigationItemMainRole
{
    public class UpdateNavigationItemMainRoleCommandHandler : ICommandHandler<UpdateNavigationItemMainRoleCommand, UpdateNavigationItemMainRoleCommandResponse>
    {
        private readonly INavigationItemMainRoleService _navItemMainRoleService;

        public UpdateNavigationItemMainRoleCommandHandler(INavigationItemMainRoleService navItemMainRoleService)
        {
            _navItemMainRoleService = navItemMainRoleService;
        }

        public async Task<UpdateNavigationItemMainRoleCommandResponse> Handle(UpdateNavigationItemMainRoleCommand request, CancellationToken cancellationToken)
        {
            var navItemMainRole = await _navItemMainRoleService.GetById(request.Id);
            if (navItemMainRole == null) throw new Exception("Boyle bir kayit bulunamadi!!");

            navItemMainRole.MainRoleId = request.MainRoleId;
            navItemMainRole.NavigationItemId = request.NavigationItemId;
            await _navItemMainRoleService.UpdateAsync(navItemMainRole, cancellationToken);

            return new();
        }
    }
}

