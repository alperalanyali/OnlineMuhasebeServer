using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;
using Domain.AppEntities.Identity;

namespace Domain.AppEntities
{
	public class MainRoleUser:Entity
	{
		public MainRoleUser()
		{

		}


		public MainRoleUser(string userId,string mainRoleId,string companyId)
		{
			Id = Guid.NewGuid().ToString();
			UserId = userId;
			MainRoleId = mainRoleId;
			CompanyId = companyId;
		}
		[ForeignKey("AppUser")]
		public string UserId { get; set; }
		public AppUser AppUser { get; set; }

		[ForeignKey("MainRole")]
		public string MainRoleId { get; set; }
		public MainRole MainRole { get; set; }


		[ForeignKey("Company")]
		public string? CompanyId { get; set; }
		public Company? Company { get; set; }
	}
}

