using System;

using FluentValidation;

namespace Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry
{
	public sealed class CreateBookEntryValidator:AbstractValidator<CreateBookEntryCommand>
	{
		public CreateBookEntryValidator()
		{
			RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz");
            RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz");
            RuleFor(p => p.Date).NotNull().WithMessage("Tarih bilgisi boş olamaz");
            RuleFor(p => p.Date).NotEmpty().WithMessage("Şirket bilgisi boş olamaz");
            RuleFor(p => p.Description).NotNull().WithMessage("Açıklama bilgisi boş olamaz");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Şirket bilgisi boş olamaz");
            RuleFor(p => p.Type).NotEmpty().WithMessage("Tip bilgisi boş olamaz");
            RuleFor(p => p.Type).NotNull().WithMessage("Şirket bilgisi boş olamaz");
        }
	}
}

