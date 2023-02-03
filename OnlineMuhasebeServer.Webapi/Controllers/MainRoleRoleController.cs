using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Features.AppFeatures.MainRoleRole.Commands.CreateMainRoleRole;
using Application.Features.AppFeatures.MainRoleRole.Commands.DeleteMainRoleRole;
using Application.Features.AppFeatures.MainRoleRole.Commands.UpdateMainRoleRole;
using Application.Features.AppFeatures.MainRoleRole.Queries.GetAllMainRoleRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class MainRoleRoleController : ApiController
    {
        public MainRoleRoleController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateMainRoleRoleCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllMainRoleRolesCommand();

            var response = await _mediatR.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Update(UpdateMainRoleRoleCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(DeleteMainRoleRoleCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
    }
}

