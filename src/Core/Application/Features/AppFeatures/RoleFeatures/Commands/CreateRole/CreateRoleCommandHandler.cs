using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole
{
    public sealed class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, CreateRoleCommandResponse>
    {
        private readonly IRoleService _roleService;
        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateRoleCommandResponse();
            AppRole role = await _roleService.GetByCode(request.Code);

            if(role != null)
            {
                throw new Exception("Bu rol daha once eklenmistir");
            }
         
            //this.response.IsSuccess = true;
            await _roleService.AddAsync(request);           
            return response ;
        }
    }
}

