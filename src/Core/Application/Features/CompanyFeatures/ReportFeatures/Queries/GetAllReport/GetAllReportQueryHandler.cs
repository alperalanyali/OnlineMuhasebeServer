using System;
using Application.Messaging;
using Application.Services.CompanyServices;
using Domain.CompanyEntities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport
{
    public class GetAllReportQueryHandler : IQueryHandler<GetAllReportQuery, GetAllReportQueryResponse>
    {
        private readonly IReportService _reportService;

        public GetAllReportQueryHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<GetAllReportQueryResponse> Handle(GetAllReportQuery request, CancellationToken cancellationToken)
        {
            var result =await _reportService.GetAllReportsByCompanyId(request.CompanyId,request.PageNumber,request.PageSize);
            //var newList = new PaginationResult<Report>();
            return new(result);
        }
    }
}

