using System;
using Application.Services.AppServices;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole
{
    public sealed class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
        private readonly IRoleService _roleService;
        public CreateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateRoleResponse();
            AppRole role = await _roleService.GetByCode(request.Code);

            if(role != null)
            {
                throw new Exception("Bu rol daha once eklenmistir");
            }
         
            response.IsSuccess = true;
            await _roleService.AddAsync(request);           
            return response ;
        }
    }
}

