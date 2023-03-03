using System;
using Application.Messaging;
using Application.Services;
using Application.Services.CompanyServices;
using Domain.Dtos;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace Application.Features.CompanyFeatures.BookEntryFeatures.Quries.GetAllBookEntries
{
    public class GetAllBookEntriesQueryHandler : IQueryHandler<GetAllBookEntriesQuery, PaginationResult<GetAllBookEntriesQueryResponse>>
    {
        private readonly IBookEntryService _bookEntryService;
        private readonly IApiService _apiService;
        public GetAllBookEntriesQueryHandler(IBookEntryService bookEntryService,IApiService apiService)
        {
            _bookEntryService = bookEntryService;
            _apiService = apiService;
        }

        public async Task<PaginationResult<GetAllBookEntriesQueryResponse>> Handle(GetAllBookEntriesQuery request, CancellationToken cancellationToken)
        {
 
            var result = await _bookEntryService.GetAllAsync(request.CompanyId, request.PageNumber, request.PageSize,request.Year);

            var count = _bookEntryService.GetCount(request.CompanyId);

            PaginationResult<GetAllBookEntriesQueryResponse> newResult = new(
                                                                pageNumber: request.PageNumber,
                                                                pageSize: request.PageSize,
                                                                totalCount: count,
                                                                datas: result.Datas.Select(s => new GetAllBookEntriesQueryResponse(
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
