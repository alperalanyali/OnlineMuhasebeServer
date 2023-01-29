using System;
using FluentValidation;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
	public class CreateUCAFValidator:AbstractValidator<CreateUCAFCommand>
	{
		public CreateUCAFValidator()
		{
			RuleFor(p => p.Code).NotEmpty().WithMessage("Hesap kodu boş olamaz!!");
            RuleFor(p => p.Code).NotNull().WithMessage("Hesap kodu boş olamaz!!");
			//RuleFor(p => p.Code).MinimumLength(4).WithMessage("Hesap kodu 4 karakter olmalıdır!!");
			RuleFor(p => p.Name).NotNull().WithMessage("Hesap planı adı boş olamaz!!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Hesap planı adı boş olamaz!!");
            RuleFor(p => p.Type).NotEmpty().WithMessage("Hesap planı tipi boş olamaz!!");
            RuleFor(p => p.Type).NotNull().WithMessage("Hesap planı tipi boş olamaz!!");
            RuleFor(p => p.Type).MaximumLength(1).WithMessage("Hesap planı tipi 1 karakter olmalıdır!!");
            RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz!!");
            RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz!!");
        }
	}
}

