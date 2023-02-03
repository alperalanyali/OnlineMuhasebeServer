using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Commands.CreateNavigationItemMainRole;
using Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Commands.DeleteNavigationItemMainRole;
using Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Commands.UpdateNavigationItemMainRole;
using Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleById;
using Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoleByMainRoleId;
using Application.Features.AppFeatures.NavigationItemMainRoleFeatures.Queries.GetNavigationItemMainRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class NavigationItemMainRoleController : ApiController
    {
        public NavigationItemMainRoleController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateNavigationItemMainRoleCommand request)
        {
            var response = await _mediatR.Send(request);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNavigationItemMainRole()
        {
            var request = new GetNavigationItemMainRolesQuery();
            var response = await _mediatR.Send(request);

            return Ok(response);            
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(UpdateNavigationItemMainRoleCommand request)
        {
            var response = await _mediatR.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteById(DeleteNavigationItemMainRoleCommand request)
        {
            var response = await _mediatR.Send(request);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNavigationItemMainRoleByMainRoleId(string mainRoleId)
        {
            var request = new GetNavigationItemMainRoleByMainRoleIdQuery(mainRoleId);
            var response = await _mediatR.Send(request);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNavigationItemMainRoleById(string id)
        {
            var request = new GetNavigationItemMainRoleByIdQuery(id);
            var response = await _mediatR.Send(request);

            return Ok(response);
        }
    }
}

