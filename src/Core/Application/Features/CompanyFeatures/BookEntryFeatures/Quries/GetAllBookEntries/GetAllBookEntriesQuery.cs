using System;
using Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;
namespace Application.Features.CompanyFeatures.BookEntryFeatures.Quries.GetAllBookEntries
{
	public sealed record GetAllBookEntriesQuery(
		string CompanyId,
		int Year,
		int PageNumber=1,
		int PageSize=10
		):IQuery<PaginationResult<GetAllBookEntriesQueryResponse>>;
	
}

