using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole;
using Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles;
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
            GelAllRolesCommand request = new GelAllRolesCommand();
            GetAllRequestCommandResponse response = await _mediatR.Send(request);

            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand request)
        {
            UpdateRoleCommandResponse response = await _mediatR.Send(request);

            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteROle(DeleteRoleCommand request)
        {
            var response = await _mediatR.Send(request);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CreateAllRoles()
        {
            CreateAllRolesCommand request = new CreateAllRolesCommand();
            CreateAllRolesResponse response = await _mediatR.Send(request);

            return Ok(response);

        }
    }
}

