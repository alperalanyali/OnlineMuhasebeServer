using System;
using Domain.CompanyEntities;
using Domain.Dtos;
using EntityFrameworkCorePagination.Nuget.Pagination;
namespace Application.Services.CompanyServices
{
	public interface IBookEntryService
	{

		Task AddAsync(string companyId, BookEntry bookEntry, CancellationToken cancellationToken);
		Task<string> GetNewBookEntryNumber(string companyId);
		Task<PaginationResult<BookEntry>>GetAllAsync(string companyId,int pageNumber,int pageSize);
		int GetCount(string companyId);
	}
}

