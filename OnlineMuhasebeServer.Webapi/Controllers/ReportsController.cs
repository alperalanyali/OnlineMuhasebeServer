using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class ReportsController : ApiController
    {
        public ReportsController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll(GetAllReportQuery request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RequestReport(RequestReportCommand request,CancellationToken cancellationToken)
        {
            var response = await _mediatR.Send(request,cancellationToken);
            return Ok(response);
        }
    }
}

