using System;
using Domain.CompanyEntities;
using Domain.Repository.AppDbContext.CompanyRepositories;

namespace Domain.Repository.CompanyDbContext.BookEntryRepositories
{
	public interface IBookEntryCommandRepository: ICompanyDbCommandRepository<BookEntry>
    {
	}
}

