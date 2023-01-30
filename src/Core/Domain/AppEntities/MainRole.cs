using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.AppEntities
{
	public class MainRole:Entity
	{	
		public string Title { get; set; }

		[ForeignKey("Company")]
		public string CompanyId { get; set; }
		public Company? Company { get; set; }

		public bool IsRoleCreatedByAdmin { get; set; }

		
        public ICollection<MainRoleUser> MainRoleUsers { get; set; }

    }
}

