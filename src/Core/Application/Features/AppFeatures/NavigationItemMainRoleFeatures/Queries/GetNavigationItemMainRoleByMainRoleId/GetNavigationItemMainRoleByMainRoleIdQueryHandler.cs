using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.Dtos;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleByMainRoleId
{
    public class GetNavigationItemMainRoleByMainRoleIdQueryHandler : IQueryHandler<GetNavigationItemMainRoleByMainRoleIdQuery, GetNavigationItemMainRoleByMainRoleIdQueryRespone>
    {
        private readonly INavigationItemMainRoleService _navItemMainRoleService;
        private readonly IMainRoleUserService _mainRoleUserservice;
        public GetNavigationItemMainRoleByMainRoleIdQueryHandler(INavigationItemMainRoleService navItemMainRoleService,IMainRoleUserService mainRoleUserService)
        {
            _navItemMainRoleService = navItemMainRoleService;
            _mainRoleUserservice = mainRoleUserService;
        }

        public async Task<GetNavigationItemMainRoleByMainRoleIdQueryRespone> Handle(GetNavigationItemMainRoleByMainRoleIdQuery request, CancellationToken cancellationToken)
        {

            var mainRoleId = await _mainRoleUserservice.GetMainRoleByUserId(request.UserId);
            var navItemMainRoles = await _navItemMainRoleService.GetNavigationItemMainRolesByMainRoleId(mainRoleId.MainRoleId);
            var dtos = navItemMainRoles.Select(s => new NavigationItemDto(s.Id,s.NavigationItem.NavigationName,s.NavigationItem.NavigationPath) ).ToList();
            return new(navItemMainRoles.Count(), dtos);
        }
    }
}

