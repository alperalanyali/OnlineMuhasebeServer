using System;
using FluentValidation;

namespace Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
	public  sealed class CreateCompanyValidator:AbstractValidator<CreateCompanyCommand>
	{
		public CreateCompanyValidator()
		{
			RuleFor(p => p.Name).NotEmpty().WithMessage("Şirket adı bilgisi yazilmalidir!!");

			RuleFor(p => p.DatabaseName).NotEmpty().WithMessage("Database bilgisi yazilmalıdır!");
            RuleFor(p => p.DatabaseName).NotNull().WithMessage("Database bilgisi yazilmalıdır!");
            RuleFor(p => p.ServerName).NotEmpty().WithMessage("Server adı bilgisi yazilmalidir!");
            RuleFor(p => p.ServerName).NotNull().WithMessage("Server adı bilgisi yazilmalidir!");
			RuleFor(p => p.ServerUserId).NotEmpty().WithMessage("Server kullanıcı bilgisi yazilmalidir!!");
            RuleFor(p => p.ServerUserId).NotNull().WithMessage("Server kullanıcı bilgisi yazilmalidir!!");
			RuleFor(p => p.ServerPassword).NotEmpty().WithMessage("Server sifresi bilgisi yazilmalidir!!");
            RuleFor(p => p.ServerPassword).NotNull().WithMessage("Server sifresi bilgisi yazilmalidir!!");
        }
	}
}

