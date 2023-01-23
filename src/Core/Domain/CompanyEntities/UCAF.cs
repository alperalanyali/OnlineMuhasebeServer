using System;
using Domain.Abstractions;

namespace Domain.CompanyEntities
{
	public sealed class UCAF:Entity
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }

		public string CompanyId { get; set; }
	}
}

