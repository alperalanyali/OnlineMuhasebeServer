using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;
using Domain.AppEntities.Identity;

namespace Domain.AppEntities
{
	public class AppUserCompany:Entity
	{

		public AppUserCompany()
		{

		}
		public AppUserCompany(string userId,string companyId)
		{
			Id = Guid.NewGuid().ToString();
			AppUserId = userId;
			CompanyId = companyId;
		}
		[ForeignKey("AppUser")]
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }

		[ForeignKey("Company")]
		public string CompanyId { get; set; }
		public Company Company { get; set; }
	}
}

