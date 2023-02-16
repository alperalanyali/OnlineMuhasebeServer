using System;
using Application.Messaging;

namespace Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport
{
	public sealed record RequestReportCommand(
		string CompanyId,
		string Name
		):ICommand<RequestReportResponse>;
	
}

