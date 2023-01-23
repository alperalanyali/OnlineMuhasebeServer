using System;
namespace Domain.Abstractions
{
	public class Entity
	{
		public string Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}

