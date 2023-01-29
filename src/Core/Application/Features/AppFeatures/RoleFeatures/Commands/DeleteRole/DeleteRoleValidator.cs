using System;
using FluentValidation;

namespace Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
	public class DeleteRoleValidator:AbstractValidator<DeleteRoleCommand>
	{
		public DeleteRoleValidator()
		{
			RuleFor(p => p.Id).NotEmpty().WithMessage("Rol id boş olamaz!!");
            RuleFor(p => p.Id).NotNull().WithMessage("Rol id boş olamaz!!");
        }
	}
}

