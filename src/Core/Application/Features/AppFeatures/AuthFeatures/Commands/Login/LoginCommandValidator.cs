using System;
using FluentValidation;

namespace Application.Features.AuthFeatures.Commands.Login
{
	public  sealed class LoginCommandValidator:AbstractValidator<LoginCommand>
	{
		public LoginCommandValidator()
		{
			RuleFor(p => p.EmailOrUsername).NotEmpty().WithMessage("Eposta ya da kullanıcı adı yazmalısınız!");
			RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre bilgisi boş olamaz!");
            RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir");
        }
	}
}

