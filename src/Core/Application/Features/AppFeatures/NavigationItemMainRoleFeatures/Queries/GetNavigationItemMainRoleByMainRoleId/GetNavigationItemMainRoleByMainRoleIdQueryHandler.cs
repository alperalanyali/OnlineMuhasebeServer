using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleByMainRoleId
{
    public class GetNavigationItemMainRoleByMainRoleIdQueryHandler : IQueryHandler<GetNavigationItemMainRoleByMainRoleIdQuery, GetNavigationItemMainRoleByMainRoleIdQueryRespone>
    {
        private readonly INavigationItemMainRoleService _navItemMainRoleService;

        public GetNavigationItemMainRoleByMainRoleIdQueryHandler(INavigationItemMainRoleService navItemMainRoleService)
        {
            _navItemMainRoleService = navItemMainRoleService;
        }

        public async Task<GetNavigationItemMainRoleByMainRoleIdQueryRespone> Handle(GetNavigationItemMainRoleByMainRoleIdQuery request, CancellationToken cancellationToken)
        {
            var navItemMainRoles = await _navItemMainRoleService.GetNavigationItemMainRolesByMainRoleId(request.MainRoleId);

            return new(navItemMainRoles.Count(), navItemMainRoles);
        }
    }
}

