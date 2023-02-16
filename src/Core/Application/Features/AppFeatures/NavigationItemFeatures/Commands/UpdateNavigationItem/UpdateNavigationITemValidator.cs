using System;
using FluentValidation;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Commands.UpdateNavigationItem
{
	public class UpdateNavigationITemValidator: AbstractValidator<UpdateNavigationItemCommand>
    {
		public UpdateNavigationITemValidator()
		{
			RuleFor(p => p.NavigationName).NotEmpty().WithMessage("Boş olamaz");
		}
	}
}

