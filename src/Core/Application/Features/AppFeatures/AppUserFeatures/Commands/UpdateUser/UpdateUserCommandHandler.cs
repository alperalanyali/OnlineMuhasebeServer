using System;
using Application.Messaging;
using Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.AppFeatures.AppUserFeatures.Commands.UpdateUser
{
	public class UpdateUserCommandHandler:ICommandHandler<UpdateUserCommand,UpdateUserCommandResponse>
	{
        private readonly UserManager<AppUser> _userManager;

        public UpdateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.FullName = request.FullName;
            await _userManager.UpdateAsync(user);

            return new();
        }
    }
}

