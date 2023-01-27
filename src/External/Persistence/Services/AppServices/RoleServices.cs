using System;
using Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole;
using Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using Application.Services.AppServices;
using AutoMapper;
using Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.AppServices
{
    public class RoleServices : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        public RoleServices(RoleManager<AppRole>  roleManager,IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateRoleCommand request)
        {
            AppRole role = _mapper.Map<AppRole>(request);
            role.Id = Guid.NewGuid().ToString();
            await _roleManager.CreateAsync(role);

        }

        public async Task DeleteByIdAsync(string id)
        {
            AppRole role = await GetById(id);
            await _roleManager.DeleteAsync(role);
        }

        public async Task<IList<AppRole>> GetAllRolesAsync()
        {
            List<AppRole> roles = await _roleManager.Roles.ToListAsync();
            return (IList<AppRole>)roles;
        }

        public async Task<AppRole> GetByCode(string code)
        {
            AppRole role = await _roleManager.Roles.Where(p => p.Code == code).FirstOrDefaultAsync();
            return role;
        }

        public async Task<AppRole> GetById(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);

            return role;

        }

        public async Task UpdateAsync(AppRole role)
        {            
            await _roleManager.UpdateAsync(role);
        }
    }
}

