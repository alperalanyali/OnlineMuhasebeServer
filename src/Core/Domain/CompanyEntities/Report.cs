using System;
using Domain.Abstractions;

namespace Domain.CompanyEntities
{
	public sealed class Report:Entity
	{
	


		public string Name { get; set; }
		public Boolean Status { get; set; }
		public string FileUrl { get; set; }

	}
}

