using System;
using System.Collections.Generic;
using Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleByUserId;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities;
using Domain.Dtos;

namespace Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleByUserId
{
    public class GetNavigationItemMainRoleByUserIdQueryHandler : IQueryHandler<GetNavigationItemMainRoleByUserIdQuery, GetNavigationItemMainRoleByUserIdQueryRespone>
    {
        private readonly INavigationItemMainRoleService _navItemMainRoleService;
        private readonly INavigationItemService _navItemService;
        private readonly IMainRoleUserService _mainRoleUserservice;
        public GetNavigationItemMainRoleByUserIdQueryHandler(INavigationItemMainRoleService navItemMainRoleService,IMainRoleUserService mainRoleUserService,INavigationItemService navigationItemService)
        {
            _navItemMainRoleService = navItemMainRoleService;
            _mainRoleUserservice = mainRoleUserService;
            _navItemService = navigationItemService;
        }

        public async Task<GetNavigationItemMainRoleByUserIdQueryRespone> Handle(GetNavigationItemMainRoleByUserIdQuery request, CancellationToken cancellationToken)
        {

            var mainRoleId = await _mainRoleUserservice.GetMainRoleByUserId(request.UserId);
            var navItemMainRoles = await _navItemMainRoleService.GetNavigationItemMainRolesByUserId(mainRoleId.MainRoleId);
            List<NavigationItemDto> dtos = new List<NavigationItemDto>();
            for (int i = 0; i < navItemMainRoles.Count(); i++)
            {
                if (navItemMainRoles[i].NavigationItem.TopNavigationId == "")
                {
                    List<NavigationItem> list = new List<NavigationItem>();

                    list = await _navItemService.GetNavigationItemsByTopNavBarId(navItemMainRoles[i].NavigationItem.NavigationName);
                    var subMenuDto = list.Select(p => new NavigationItemDto(p.Id, p.NavigationName, p.NavigationPath, p.TopNavigationId, null)).ToList();
                    dtos.Add(new NavigationItemDto(navItemMainRoles[i].NavigationItem.Id, navItemMainRoles[i].NavigationItem.NavigationName, navItemMainRoles[i].NavigationItem.NavigationPath, navItemMainRoles[i].NavigationItem.TopNavigationId, subMenuDto));
                }        
            }
            //var dtos = navItemMainRoles.Select(s => new NavigationItemDto(s.Id,s.NavigationItem.NavigationName,s.NavigationItem.NavigationPath,s.NavigationItem.TopNavigationId, null)).ToList();
            return new(dtos.Count(), dtos);
        }
    }
}

