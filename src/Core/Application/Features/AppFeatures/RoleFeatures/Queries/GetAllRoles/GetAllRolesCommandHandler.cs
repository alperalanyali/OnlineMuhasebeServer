using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
    public sealed class GetAllRolesCommandHandler : IQueryHandler<GelAllRolesCommand, GetAllRequestCommandResponse>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<GetAllRequestCommandResponse> Handle(GelAllRolesCommand request, CancellationToken cancellationToken)
        {

            IList<AppRole> roles = await _roleService.GetAllRolesAsync();
            var response = new GetAllRequestCommandResponse() { results = roles.Count,Roles = roles};

            return response;

        }
    }
}

