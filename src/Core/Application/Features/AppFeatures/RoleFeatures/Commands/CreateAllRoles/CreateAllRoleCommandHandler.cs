using System;
using Application.Messaging;
using Application.Roles;
using Application.Services.AppServices;
using Domain.AppEntities.Identity;

namespace Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles
{
    public sealed class CreateAllRoleCommandHandler : ICommandHandler<CreateAllRolesCommand, CreateAllRolesResponse>
    {
        IList<AppRole> roles = RoleList.GetStaticRoles();
        private readonly IRoleService _roleService;
        public CreateAllRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<CreateAllRolesResponse> Handle(CreateAllRolesCommand request, CancellationToken cancellationToken)
        {
            IList<AppRole> originalList = RoleList.GetStaticRoles();
            IList<AppRole> newList = RoleList.GetStaticRoles();
            foreach (var role in originalList)
            {
                AppRole checkRole = await _roleService.GetByCode(role.Code);
                if(checkRole == null)
                {
                    newList.Add(role);
                }

                await _roleService.AddRangeAsync(newList);
                return new();
            }

            throw new NotImplementedException();
        }
    }
}

