using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;
using Domain.AppEntities.Identity;

namespace Domain.AppEntities
{
	public class MainRoleRole:Entity
	{
		public MainRoleRole()
		{

		}
		public MainRoleRole(string mainRoleId,string roleId)
		{
			Id = Guid.NewGuid().ToString();

			MainRoleId = mainRoleId;
			RoleId = roleId;
		}


		[ForeignKey("MainRole")]
		public string MainRoleId { get; set; }

		public MainRole MainRole { get; set; }

		[ForeignKey("AppRole")]
		public string RoleId { get; set; }
		public AppRole  AppRole { get; set; }

	}
}

