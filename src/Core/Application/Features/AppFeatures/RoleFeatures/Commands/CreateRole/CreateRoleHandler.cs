using System;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole
{
    public sealed class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
        private readonly RoleManager<AppRole> _roleManager;
        public CreateRoleHandler(RoleManager<AppRole>  roleManager)
        {
            _roleManager = roleManager;
        }


        public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateRoleResponse();
            AppRole role = await _roleManager.Roles.Where(p => p.Code == request.Code).FirstOrDefaultAsync();

            if(role != null)
            {
                throw new Exception("Bu rol daha once eklenmistir");
            }
            role =new AppRole(){
                Id = Guid.NewGuid().ToString(),
                Code = request.Code,
                Name = request.Name
            };
            response.IsSuccess = true;
            await _roleManager.CreateAsync(role);           
            return response ;
        }
    }
}

