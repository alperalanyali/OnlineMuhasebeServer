using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AppFeatures.AppUserFeatures.Commands.CreateUser;
using Application.Features.AppFeatures.AppUserFeatures.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
    }
}

