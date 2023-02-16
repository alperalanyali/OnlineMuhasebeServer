using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Abstractions;
using Domain.AppEntities.Identity;
using Domain.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<AppUser> _userManager;


        public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
        }

        public async Task<TokenRefreshTokenDto> CreateToken(AppUser user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.FullName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Authentication,user.Id),
                //new Claim(ClaimTypes.Role,string.Join(",",roles))

            };
            DateTime expires = DateTime.Now.AddMinutes(15);
            JwtSecurityToken jwtSecurityToken = new(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expires,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),SecurityAlgorithms.HmacSha256)
                ) ;

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpires = expires.AddMinutes(15);
            await _userManager.UpdateAsync(user);

            return new(token,refreshToken,user.RefreshTokenExpires);
        }
    }
}

