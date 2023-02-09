using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AppFeatures.UserFeatures.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class UserController : ApiController
    {
        public UserController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var request = new GetAllUserQuery();
            var response = await _mediatR.Send(request);

            return Ok(response);
        }
    }
}

