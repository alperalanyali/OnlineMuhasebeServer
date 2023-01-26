using System;
using Application.Services.AppServices;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
	public class UpdateRoleHandler:IRequestHandler<UpdateRoleRequest,UpdateRoleResponse>
	{
        private readonly IRoleService _roleService;
        public UpdateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetById(request.Id);
            var response = new UpdateRoleResponse();
            if (role == null)
            {
                throw new Exception("Role bulunamadi");
            }

            if(request.Code != role.Code)
            {
                AppRole checkCode = await _roleService.GetByCode(request.Code);
                if(checkCode != null)
                {
                    throw new Exception("Bu kod daha once kaydedilmistir!!");
                }
                role.Code = request.Code;
                role.Name = request.Name;               
                await _roleService.UpdateAsync(role);

             
                response.IsSuccess = true;

            }

            return response;
        }
    }
}

