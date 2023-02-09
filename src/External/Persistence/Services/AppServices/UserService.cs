using System;
using Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Services.AppServices
{
	public class UserService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly AppDbContext _appDbContext;

		public UserService(UserManager<AppUser> userManager,AppDbContext appDbContext)
		{
			_userManager = userManager;
			_appDbContext = appDbContext;
		}


		public async Task<IList<AppUser>> GetAllUsers()
		{
			return await _userManager.Users.ToListAsync();
		}
	}
}

