using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, DeleteRoleCommandResponse>
    {
        private readonly IRoleService _roleService;
        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
   

        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetById(request.Id);
            if (role == null)
            {                
                throw new Exception("Rol bulunamadi!!");
            }
                
            await _roleService.DeleteByIdAsync(request.Id);

            DeleteRoleCommandResponse response = new DeleteRoleCommandResponse();
            return response;
        }
    }
}

