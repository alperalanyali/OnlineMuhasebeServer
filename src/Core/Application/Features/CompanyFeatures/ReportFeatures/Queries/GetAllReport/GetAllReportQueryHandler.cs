using System;
using Application.Messaging;
using Application.Services.CompanyServices;

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
            var result =await _reportService.GetAllReportsByCompanyId(request.CompanyId);

            return new(result.Count(),result);
        }
    }
}

