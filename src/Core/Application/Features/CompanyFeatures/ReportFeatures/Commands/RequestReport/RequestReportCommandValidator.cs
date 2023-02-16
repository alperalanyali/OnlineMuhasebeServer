using System;
using FluentValidation;

namespace Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport
{
	public class RequestReportCommandValidator : AbstractValidator<RequestReportCommand> {

		public RequestReportCommandValidator()
		{
			RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz");
            RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Rapor adı boş olamaz");
            RuleFor(p => p.Name).NotNull().WithMessage("Rapor adı boş olamaz");
        }
	}
}

