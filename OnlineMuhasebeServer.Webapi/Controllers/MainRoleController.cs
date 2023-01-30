using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AppFeatures.MainRole.Commands.CreateMainRole;
using Application.Features.AppFeatures.MainRole.Commands.CreateStaticMainRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class MainRoleController : ApiController
    {
        public MainRoleController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewRole(CreateMainRoleCommand request,CancellationToken cancellationToken)
        {
            CreateRoleResponse response = await _mediatR.Send(request,cancellationToken);
            return Ok(response);

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateStaticMainRole(CreateStaticMainRolesCommand request)
        {            
            CreateStaticMainRolesResponse createStaticMainRolesResponse = await _mediatR.Send(request);

            return Ok(createStaticMainRolesResponse);
        }
    }
}

