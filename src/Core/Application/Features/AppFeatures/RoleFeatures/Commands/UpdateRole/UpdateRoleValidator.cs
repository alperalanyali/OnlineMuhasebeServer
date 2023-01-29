using System;
using FluentValidation;

namespace Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
	public class UpdateRoleValidator:AbstractValidator<UpdateRoleCommand>
	{
		public UpdateRoleValidator()
		{
			RuleFor(p => p.Id).NotEmpty().WithMessage("Rol id boş olamaz!!");
            RuleFor(p => p.Id).NotNull().WithMessage("Rol id boş olamaz!!");
            RuleFor(p => p.Code).NotEmpty().WithMessage("Rol kodu boş olamaz!!");
            RuleFor(p => p.Code).NotNull().WithMessage("Rol kodu boş olamaz!!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Rol adı boş olamaz!!");
            RuleFor(p => p.Name).NotNull().WithMessage("Rol adı boş olamaz!!");
        }
	}
}

