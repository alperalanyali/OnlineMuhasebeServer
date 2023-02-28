using System;
using Application.Messaging;
using Application.Services.CompanyServices;
using Domain.Dtos;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace Application.Features.CompanyFeatures.BookEntryFeatures.Quries.GetAllBookEntries
{
    public class GetAllBookEntriesQueryHandler : IQueryHandler<GetAllBookEntriesQuery, PaginationResult<GetAllBookEntriesQueryResponse>>
    {
        private readonly IBookEntryService _bookEntryService;

        public GetAllBookEntriesQueryHandler(IBookEntryService bookEntryService)
        {
            _bookEntryService = bookEntryService;
        }

        public async Task<PaginationResult<GetAllBookEntriesQueryResponse>> Handle(GetAllBookEntriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookEntryService.GetAllAsync(request.CompanyId, request.PageNumber, request.PageSize);

            var count = _bookEntryService.GetCount(request.CompanyId);
            PaginationResult<BookEntryDto> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Select(s => new BookEntryDto(
                s.Id,
                s.BookEntryNumber,
                s.Date,
                s.Description,
                s.Type,
                0,
                0)).ToList());

         
            return newResult;
        }
    }

}
