using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole;
using Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class RoleController : ApiController
    {
        public RoleController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateRoleCommand request)
        {
            CreateRoleCommandResponse response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoles()
        {
            GelAllRolesRequest request = new GelAllRolesRequest();
            GetAllRequestResponse response = await _mediatR.Send(request);

            return Ok(response);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRole(UpdateRoleRequest request)
        {
            UpdateRoleResponse response = await _mediatR.Send(request);

            return Ok(response);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteROle(DeleteRoleCommand request)
        {
            var response = await _mediatR.Send(request);

            return Ok(response);
        }
    }
}

