using System;
using Application.Messaging;
using Application.Services.CompanyServices;
using Domain.CompanyEntities;

namespace Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport
{
	public class RequestReportCommandHandler:ICommandHandler<RequestReportCommand,RequestReportResponse>
	{
        private readonly IReportService _reportService;
		public RequestReportCommandHandler(IReportService reportService)
		{
            _reportService = reportService;
		}

        public async Task<RequestReportResponse> Handle(RequestReportCommand request, CancellationToken cancellationToken)
        {
        
            await _reportService.Request(request, cancellationToken);
            return new();
        }
    }
}

