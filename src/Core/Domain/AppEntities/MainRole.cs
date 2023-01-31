using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.AppEntities
{
	public class MainRole:Entity
	{

		public MainRole()
		{

		}

		public MainRole(string title/*,string companyId = ""*/,bool isRoleCreatedByAdmin = false)
		{
			Id = Guid.NewGuid().ToString();
			Title = title;
			//CompanyId = companyId;
			IsRoleCreatedByAdmin = isRoleCreatedByAdmin;
		}
        public MainRole(string title,string companyId = "", bool isRoleCreatedByAdmin = false)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            CompanyId = companyId;
			IsRoleCreatedByAdmin = isRoleCreatedByAdmin;
        }
        public string Title { get; set; }

		[ForeignKey("Company")]
		public string? CompanyId { get; set; }
		public Company? Company { get; set; }

		public bool IsRoleCreatedByAdmin { get; set; }

		
        public ICollection<MainRoleUser> MainRoleUsers { get; set; }

    }
}

