using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoles
{
    public class GetNavigationItemMainRolesQueryHandler : IQueryHandler<GetNavigationItemMainRolesQuery, GetNavigationItemMainRolesQueryResponse>
    {
        private readonly INavigationItemMainRoleService _navItemMainRoleService;

        public GetNavigationItemMainRolesQueryHandler(INavigationItemMainRoleService navItemMainRoleService)
        {
            _navItemMainRoleService = navItemMainRoleService;
        }

        public async Task<GetNavigationItemMainRolesQueryResponse> Handle(GetNavigationItemMainRolesQuery request, CancellationToken cancellationToken)
        {
            var navItemMainRoles = await _navItemMainRoleService.GetNavigationItemMainRoles();
            return new(navItemMainRoles.Count(), navItemMainRoles);
        }
    }
}

