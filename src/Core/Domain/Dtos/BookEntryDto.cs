using System;
namespace Domain.Dtos
{
	public class BookEntryDto
	{
		public string Id { get; set; }
        public string BookEntryNumber { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }        
        public decimal Debt { get; set; }
        public decimal Credit { get; set; }

        public BookEntryDto(string id,string bookEntryNumber,DateTime date,string description,string type,decimal debt,decimal credit)
        {
            Id = id;
            BookEntryNumber = bookEntryNumber;
            Date = date;
            Description = description;
            Type = type;
            Debt = debt;
            Credit = credit;
        }

    }
}

