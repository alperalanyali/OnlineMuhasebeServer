using System;
using Application.Services.AppServices;
using Azure.Core;
using Domain.AppEntities;
using Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.AppServices
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserCompanyService _userCompanyService;
        private readonly IMainRoleUserService _mainRoleUserService;
        private readonly IMainRoleRoleService _mainRoleRoleService;
        public AuthService(UserManager<AppUser> userManager, IUserCompanyService userCompanyService, IMainRoleUserService mainRoleUserService, IMainRoleRoleService mainRoleRoleService)
        {
            _userManager = userManager;
            _userCompanyService = userCompanyService;
            _mainRoleUserService = mainRoleUserService;
            _mainRoleRoleService = mainRoleRoleService;
        }

        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }

        public async Task<AppUser> GetByEmailOrUsernameAsync(string emailOrUsername)
        {
           return await _userManager.Users.Where(p => p.Email == emailOrUsername
                                                            || p.UserName == emailOrUsername).FirstOrDefaultAsync();
        }

        public async Task<IList<AppUserCompany>> GetCompanyListAsync(string userId)
        {
            return await _userCompanyService.GetCompanyListByUserId(userId);
        }

        public async Task<IList<string>> GetRolesByUserIdAndCompany(string userId, string companyId)
        {
            MainRoleUser mainRoleUser = await _mainRoleUserService.GetRolesByUserIdAndCompany(userId, companyId);

            var getRoles = await _mainRoleRoleService.GetMainRoleRoleByMainRoleId(mainRoleUser.MainRoleId);
            IList<string> roles = getRoles.Select(p => p.AppRole.Name).ToList();
            return roles;
           // return roles.AppRole.Name;
        }
    }
}

