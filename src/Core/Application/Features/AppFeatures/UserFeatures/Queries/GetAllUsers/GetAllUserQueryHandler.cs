using System;
using Application.Messaging;
using Domain.AppEntities.Identity;
using Domain.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.UserFeatures.Queries.GetAllUsers
{
    public class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, GetAllUserQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetAllUserQueryHandler(UserManager<AppUser>  userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync();
            var userDto = users.Select(s => new UserDto(s.Id,s.UserName,s.FullName,s.PhoneNumber,s.Email));
            return new(userDto.Count(), userDto);
        }
    }
}

