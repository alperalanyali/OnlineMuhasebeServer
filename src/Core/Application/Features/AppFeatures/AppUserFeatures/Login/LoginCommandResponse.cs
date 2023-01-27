using System;
namespace Application.Features.AppFeatures.AppUserFeatures.Login
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
            string Token,
            string Email,
            string UserId,
            string FullName
        );
}

