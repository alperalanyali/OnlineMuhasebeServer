using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
	public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, UpdateRoleCommandResponse>
	{
        private readonly IRoleService _roleService;
        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetById(request.Id);
            var response = new UpdateRoleCommandResponse();
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

