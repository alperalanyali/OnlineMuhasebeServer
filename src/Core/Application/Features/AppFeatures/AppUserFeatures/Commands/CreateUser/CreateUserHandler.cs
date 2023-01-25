using System;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.AppFeatures.AppUserFeatures.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.CreateAsync(new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName,
                Id = Guid.NewGuid().ToString(),
                RefreshToken = "adfasdf"

            }, request.Password);
            var response = new CreateUserResponse();
            if(user != null)
            {
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Kullanıcı oluşturulamadı!!";
            }

            return response;
        }
    }
}

