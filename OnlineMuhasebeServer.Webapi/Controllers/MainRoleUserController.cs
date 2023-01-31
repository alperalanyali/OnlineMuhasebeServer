using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AppFeatures.MainRoleUser.Commands.CreateMainRoleUser;
using Application.Features.AppFeatures.MainRoleUser.Commands.DeleteMainRoleUser;
using Application.Features.AppFeatures.MainRoleUser.Commands.UpdateMainRoleUser;
using Application.Features.AppFeatures.MainRoleUser.Queries.GetAllMainRoleUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class MainRoleUserController : ApiController
    {
        public MainRoleUserController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateMainRoleUserCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllMainRoleUserCommand();
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateMainRoleUserCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(DeleteMainRoleUserCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
    }
}

