using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CompanyFeatures.LogFeatures.Queries.GetLogsByTableName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    [Authorize(AuthenticationSchemes ="Bearer")]
    public class LogController : ApiController
    {
        public LogController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllByTableName(GetLogsByTableNameQuery request)
        {

            var response = await _mediatR.Send(request);
            return Ok(response);
        }

    }
}

