using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleById
{
    public class GetNavigationItemMainRoleByIdQueryHandler : IQueryHandler<GetNavigationItemMainRoleByIdQuery, GetNavigationItemMainRoleByIdQueryResponse>
    {

        private readonly INavigationItemMainRoleService _navItemMainRoleService;

        public GetNavigationItemMainRoleByIdQueryHandler(INavigationItemMainRoleService navItemMainRoleService)
        {
            _navItemMainRoleService = navItemMainRoleService;
        }

        public async Task<GetNavigationItemMainRoleByIdQueryResponse> Handle(GetNavigationItemMainRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var navItemMainRole = await _navItemMainRoleService.GetById(request.Id);

            return new(navItemMainRole);
        }
    }
}

