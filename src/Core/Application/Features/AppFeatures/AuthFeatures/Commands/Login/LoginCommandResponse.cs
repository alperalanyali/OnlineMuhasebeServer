using System;
using Domain.Dtos;

namespace Application.Features.AuthFeatures.Commands.Login
{
    //// Validation özelliğinden önceki hali
    //public class LoginResponse
    //{
    //	public string Token { get; set; } 

    //	public string Email { get; set; }
    //	public string UserId { get; set; }
    //	public string FullName { get; set; }


    //}

    public sealed record LoginCommandResponse(
            TokenRefreshTokenDto Token,        
            string Email,
            string UserId,
            string FullName,
            IList<CompanyDto> Companies,
            CompanyDto Company,
            int Year
        );
}

