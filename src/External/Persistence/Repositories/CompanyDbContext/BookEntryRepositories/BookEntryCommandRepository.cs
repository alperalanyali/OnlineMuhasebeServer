using System;
using Domain.CompanyEntities;
using Domain.Repository.CompanyDbContext.BookEntryRepositories;
using Persistence.Repositories.GenericRepositories.CompanyDbContext;

namespace Persistence.Repositories.CompanyDbContext.BookEntryRepositories
{
	public class BookEntryCommandRepository: CompanyDbCommandRepository<BookEntry>, IBookEntryCommandRepository
    {
		
	}
}

