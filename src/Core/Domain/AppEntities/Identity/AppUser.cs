using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.AppEntities.Identity
{
	public class AppUser:IdentityUser<string>
	{
		public string FullName { get; set; }
		public string RefreshToken { get; set; }
		public DateTime RefreshTokenExpires { get; set; }

	}
}

