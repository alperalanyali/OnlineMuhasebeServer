using System;
using Domain.Abstractions;

namespace Domain.CompanyEntities
{
	public sealed class BookEntry:Entity
	{
		public BookEntry()
		{

		}
		public BookEntry(string bookEntryNumber,DateTime date,string description,string type)
		{
			Id = Guid.NewGuid().ToString();
			BookEntryNumber = bookEntryNumber;
			Date = date;
			Type = type;
			Description = description;

		}
		public string BookEntryNumber { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }		
	}
}

