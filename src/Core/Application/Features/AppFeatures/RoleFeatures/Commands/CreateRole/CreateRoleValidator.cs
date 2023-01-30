using System;
using Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole;
using FluentValidation;

namespace Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole
{
	public sealed class CreateRoleValidator:AbstractValidator<CreateRoleCommand>
	{
		public CreateRoleValidator()
		{
            RuleFor(p => p.Title).NotEmpty().WithMessage("Rol başlığı boş olamaz!");
            RuleFor(p => p.Title).NotNull().WithMessage("Rol başlığı boş olamaz!");
            RuleFor(p => p.Code).NotEmpty().WithMessage("Rol kodu boş olamaz!");
            RuleFor(p => p.Code).NotNull().WithMessage("Rol kodu boş olamaz!");
			RuleFor(p => p.Name).NotNull().WithMessage("Rol adı boş olamaz!!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Rol adı boş olamaz!!");
        }
	}
}

