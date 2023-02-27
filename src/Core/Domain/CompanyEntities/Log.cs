using System;
using Domain.Abstractions;

namespace Domain.CompanyEntities
{
	public class Log:Entity
	{
		public string UserId { get; set; }
		public string TableName { get; set; }
		public string  Data { get; set; }
		public string Progress { get; set; }

	}
}

