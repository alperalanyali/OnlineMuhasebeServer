using System;
using Domain.Dtos;
using EntityFrameworkCorePagination.Nuget.Pagination;
namespace Application.Features.CompanyFeatures.BookEntryFeatures.Quries.GetAllBookEntries
{
	public sealed record GetAllBookEntriesQueryResponse(
            string Id,
            string BookEntryNumber,
            DateTime Date,
            string Description,
            string Type,
            decimal Debit,
            decimal Credit
        );

}

