using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.AppEntities
{
	public class NavigationItemMainRole:Entity
	{

		public NavigationItemMainRole()
		{

		}
		public NavigationItemMainRole(string navigationItemId,string mainRoleId)
		{
			Id = Guid.NewGuid().ToString();
			NavigationItemId = navigationItemId;
			MainRoleId = mainRoleId;

		}
		[ForeignKey("NavigationItem")]
		public string NavigationItemId { get; set; }
		public NavigationItem NavigationItem { get; set; }

		[ForeignKey("MainRole")]
		public string MainRoleId { get; set;	}
		public MainRole MainRole { get; set; }
	}
}

