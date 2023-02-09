using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.Dtos;

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
            var navItemMainRoles = await _navItemMainRoleService.GetNavigationItemMainRoles("");
            var navItemMainRoleDto = navItemMainRoles.Select(s => new NavigationItemMainRoleDto(s.Id, s.NavigationItemId, s.NavigationItem.NavigationName, s.MainRoleId, s.MainRole.Title)).ToList();
            return new(navItemMainRoles.Count(), navItemMainRoleDto);
        }
    }
}

