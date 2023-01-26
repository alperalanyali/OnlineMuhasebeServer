using System;
using Application.Services.AppServices;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
    public sealed class GetAllRolesHandler : IRequestHandler<GelAllRolesRequest, GetAllRequestResponse>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<GetAllRequestResponse> Handle(GelAllRolesRequest request, CancellationToken cancellationToken)
        {

            IList<AppRole> roles = await _roleService.GetAllRolesAsync();
            var response = new GetAllRequestResponse() { results = roles.Count,Roles = roles};

            return response;

        }
    }
}

