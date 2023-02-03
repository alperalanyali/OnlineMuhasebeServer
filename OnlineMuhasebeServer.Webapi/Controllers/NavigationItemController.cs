using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AppFeatures.NavigationItemFeatures.Commands.CreateNavigationItem;
using Application.Features.AppFeatures.NavigationItemFeatures.Commands.DeleteNavigationItem;
using Application.Features.AppFeatures.NavigationItemFeatures.Commands.UpdateNavigationItem;
using Application.Features.AppFeatures.NavigationItemFeatures.Queries.GetNavigationItemById;
using Application.Features.AppFeatures.NavigationItemFeatures.Queries.GetNavigationItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class NavigationItemController : ApiController
    {
        public NavigationItemController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateNavigationItemCommand request)
        {
            var response =await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNavigationItems()
        {
            var request = new GetNavigationItemsQuery();
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Update(UpdateNavigationItemCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(DeleteNavigationItemCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetById(string id)
        {
            var request = new GetNavigationItemByIdQuery(id);
            var response = await _mediatR.Send(request);
            return Ok(response);

        }
    }
}

