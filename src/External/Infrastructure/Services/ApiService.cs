using System;
using Application.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public sealed class ApiService : IApiService
    {
        private readonly IHttpContextAccessor _http;
        public ApiService(IHttpContextAccessor httpContextAccessor)
        {
            _http = httpContextAccessor;
        }
        public string GetUserIdByToken()
        {
            var userId = _http.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Contains("authentication"))?.Value;

            return userId ?? string.Empty;

        }
    }
}

