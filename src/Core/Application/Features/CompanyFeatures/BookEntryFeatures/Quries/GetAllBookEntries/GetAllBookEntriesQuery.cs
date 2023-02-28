using System;
using Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;
namespace Application.Features.CompanyFeatures.BookEntryFeatures.Quries.GetAllBookEntries
{
	public sealed record GetAllBookEntriesQuery(
		string CompanyId,
		int PageNumber,
		int PageSize
		):IQuery<PaginationResult<GetAllBookEntriesQueryResponse>>;
	
}

