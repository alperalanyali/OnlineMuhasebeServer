using System;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
    public sealed class GetAllRolesHandler : IRequestHandler<GelAllRolesRequest, GetAllRequestResponse>
    {
        private readonly RoleManager<AppRole> _roleManager;
        public GetAllRolesHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<GetAllRequestResponse> Handle(GelAllRolesRequest request, CancellationToken cancellationToken)
        {
            
            List<AppRole> roles = await _roleManager.Roles/*.
                                           Where(p => p.Code.ToLower().Contains(request.Search.ToLower())
                                           || p.Name.ToLower().Contains(request.Search.ToLower()))*/
                                           .ToListAsync();
            var response = new GetAllRequestResponse() { results = roles.Count,Roles = roles};

            return response;

        }
    }
}

